using System.Reflection;
using Microsoft.EntityFrameworkCore;

internal class ProductDbContext(
    DbContextOptions<ProductDbContext> options,
    IEventDispatcher eventDispatcher)
    : BaseDBContext(options, eventDispatcher)
{
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<Product> Products { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}
