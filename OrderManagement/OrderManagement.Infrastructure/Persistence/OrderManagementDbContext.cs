using System.Reflection;
using Microsoft.EntityFrameworkCore;

internal class OrderManagementDbContext : BaseDbContext<OrderManagementDbContext>
{
    public OrderManagementDbContext(
        DbContextOptions<OrderManagementDbContext> options,
        IEventDispatcher eventDispatcher)
        : base(options, eventDispatcher)
    {
    }

    public DbSet<Order> Orders { get; set; } = default!;
    public DbSet<OrderItem> OrderItems { get; set; } = default!;
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}
