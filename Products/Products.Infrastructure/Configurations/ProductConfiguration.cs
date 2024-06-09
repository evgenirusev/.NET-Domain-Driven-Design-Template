using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(ProductModelConstants.Product.MaxNameLength);

        builder.Property(p => p.Description)
            .IsRequired()
            .HasMaxLength(ProductModelConstants.Product.MaxDescriptionLength);

        builder.Property(p => p.ProductType)
            .IsRequired()
            .HasConversion<int>();

        builder.OwnsOne(p => p.Weight, w =>
        {
            w.Property(wt => wt.Value)
                .IsRequired()
                .HasColumnName("WeightValue");

            w.Property(wt => wt.Unit)
                .IsRequired()
                .HasMaxLength(ProductModelConstants.Weight.MaxUnitLength)
                .HasColumnName("WeightUnit");
        });

        builder.OwnsOne(p => p.Price, p =>
        {
            p.Property(pr => pr.Amount)
                .IsRequired()
                .HasColumnName("PriceAmount");

            p.Property(pr => pr.Currency)
                .IsRequired()
                .HasMaxLength(ProductModelConstants.Price.MaxCurrencyLength)
                .HasColumnName("PriceCurrency");
        });

        builder.HasMany(p => p.Suppliers)
            .WithMany(s => s.Products)
            .UsingEntity<Dictionary<string, object>>(
                "ProductSupplier",
                j => j.HasOne<Supplier>().WithMany().HasForeignKey("SupplierId"),
                j => j.HasOne<Product>().WithMany().HasForeignKey("ProductId"));
    }
}
