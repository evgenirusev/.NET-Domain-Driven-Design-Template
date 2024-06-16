using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.HasKey(oi => oi.Id);
        
        builder.Property(oi => oi.Id)
            .ValueGeneratedOnAdd();

        builder
            .Property(oi => oi.OrderId)
            .IsRequired();

        builder
            .Property(oi => oi.ProductId)
            .IsRequired();

        builder
            .Property(oi => oi.Quantity)
            .IsRequired();

        builder
            .HasOne<Order>()
            .WithMany(o => o.OrderItems)
            .HasForeignKey(oi => oi.OrderId);

        builder.ToTable("OrderItems");
    }
}