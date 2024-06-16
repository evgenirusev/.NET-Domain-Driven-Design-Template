using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(o => o.Id);
        
        builder.Property(o => o.Id)
            .ValueGeneratedOnAdd();

        builder
            .Property(o => o.CustomerId)
            .IsRequired();

        builder
            .Property(o => o.OrderDate)
            .IsRequired();

        builder
            .OwnsOne(o => o.Status, os =>
            {
                os.WithOwner();
                os.Property(os => os.Value).IsRequired();
            });

        builder
            .HasMany(o => o.OrderItems)
            .WithOne()
            .HasForeignKey(oi => oi.OrderId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.ToTable("Orders");
    }
}