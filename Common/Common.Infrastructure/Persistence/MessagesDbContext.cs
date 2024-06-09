using System.Reflection;
using Microsoft.EntityFrameworkCore;

internal abstract class MessagesDbContext : DbContext
{
    private readonly IEventPublisher eventPublisher;

    protected MessagesDbContext(
        DbContextOptions options,
        IEventPublisher eventPublisher)
        : base(options)
        => this.eventPublisher = eventPublisher;

    public DbSet<Message> Messages { get; set; } = default!;

    protected abstract Assembly ConfigurationsAssembly { get; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new MessageConfiguration());
        builder.ApplyConfigurationsFromAssembly(ConfigurationsAssembly);

        base.OnModelCreating(builder);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        var entities = ChangeTracker
            .Entries<IEntity>()
            .Select(e => e.Entity)
            .Where(e => e.Events.Any())
            .ToArray();

        foreach (var entity in entities)
        {
            var eventMessages = entity
                .Events
                .ToDictionary(
                    domainEvent => domainEvent,
                    domainEvent => new Message(domainEvent));

            entity.ClearEvents();

            foreach (var (_, message) in eventMessages)
            {
                Add(message);
            }

            await base.SaveChangesAsync(cancellationToken);

            foreach (var (domainEvent, message) in eventMessages)
            {
                await eventPublisher.Publish(domainEvent);

                message.MarkAsPublished();

                await base.SaveChangesAsync(cancellationToken);
            }
        }

        return await base.SaveChangesAsync(cancellationToken);
    }
}