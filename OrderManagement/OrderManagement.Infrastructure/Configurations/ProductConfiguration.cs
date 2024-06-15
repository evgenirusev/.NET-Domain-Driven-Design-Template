using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder
            .HasKey(p => p.Id);

        builder
            .OwnsOne(p => p.Price, p =>
            {
                p.WithOwner();
                
                p.Property(pr => pr.Amount)
                    .IsRequired()
                    .HasPrecision(38, 15)
                    .HasColumnName("PriceAmount");

                p.Property(pr => pr.Currency)
                    .IsRequired()
                    .HasMaxLength(OrderModelConstants.Price.MaxCurrencyLength)
                    .HasColumnName("PriceCurrency");
            });
    }
}
