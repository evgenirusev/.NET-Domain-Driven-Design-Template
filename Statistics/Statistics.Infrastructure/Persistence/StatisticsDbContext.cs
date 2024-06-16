using System.Reflection;
using Microsoft.EntityFrameworkCore;

internal class StatisticsDbContext(
    DbContextOptions<StatisticsDbContext> options,
    IEventDispatcher eventDispatcher)
    : BaseDBContext(options, eventDispatcher)
{
    public DbSet<Statistics> Statistics { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}
