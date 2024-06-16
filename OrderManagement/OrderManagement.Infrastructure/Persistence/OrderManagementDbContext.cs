using System.Reflection;
using Microsoft.EntityFrameworkCore;

internal class OrderManagementDbContext(
    DbContextOptions<OrderManagementDbContext> options,
    IEventDispatcher eventDispatcher)
    : BaseDBContext(options, eventDispatcher)
{
    public DbSet<Order> Orders { get; set; } = default!;
    public DbSet<OrderItem> OrderItems { get; set; } = default!;
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}