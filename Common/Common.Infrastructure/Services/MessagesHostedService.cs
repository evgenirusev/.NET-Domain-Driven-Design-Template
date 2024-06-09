using Hangfire;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

internal class MessagesHostedService : IHostedService
{
    private const string CronExpression = "*/5 * * * * *";

    private readonly IEventPublisher eventPublisher;
    private readonly IRecurringJobManager recurringJob;
    private readonly IServiceScopeFactory serviceScopeFactory;

    public MessagesHostedService(
        IEventPublisher eventPublisher,
        IRecurringJobManager recurringJob,
        IServiceScopeFactory serviceScopeFactory)
    {
        this.eventPublisher = eventPublisher;
        this.recurringJob = recurringJob;
        this.serviceScopeFactory = serviceScopeFactory;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        using var scope = serviceScopeFactory.CreateScope();

        var data = scope.ServiceProvider.GetService<DbContext>();

        if (!data!.Database.CanConnect())
        {
            data.Database.Migrate();
        }

        recurringJob.AddOrUpdate(
            nameof(MessagesHostedService),
            () => ProcessPendingMessages(),
            CronExpression);

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
        => Task.CompletedTask;

    public void ProcessPendingMessages()
    {
        using var scope = serviceScopeFactory.CreateScope();

        var data = scope.ServiceProvider.GetService<DbContext>();

        var messages = data!
            .Set<Message>()
            .Where(m => !m.Published)
            .OrderBy(m => m.Id)
            .ToList();

        foreach (var message in messages)
        {
            eventPublisher
                .Publish(message.Data, message.Type)
                .GetAwaiter()
                .GetResult();

            message.MarkAsPublished();

            data.SaveChanges();
        }
    }
}