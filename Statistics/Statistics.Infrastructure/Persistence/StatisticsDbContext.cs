using System.Reflection;
using Microsoft.EntityFrameworkCore;

internal class StatisticsDbContext : BaseDbContext<StatisticsDbContext>
{
    public StatisticsDbContext(
        DbContextOptions<StatisticsDbContext> options,
        IEventDispatcher eventDispatcher)
        : base(options, eventDispatcher)
    {
    }

    public DbSet<TotalStatistics> TotalStatistics { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}
