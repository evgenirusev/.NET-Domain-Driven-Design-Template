using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
{
    public void Configure(EntityTypeBuilder<Supplier> builder)
    {
        builder.ToTable("Suppliers");

        builder.HasKey(s => s.Id);
        
        builder.Property(s => s.Id)
            .ValueGeneratedOnAdd();

        builder.Property(s => s.Name)
            .IsRequired()
            .HasMaxLength(SupplierModelConstants.Common.MaxNameLength);

        builder.Property(s => s.ContactEmail)
            .IsRequired()
            .HasMaxLength(SupplierModelConstants.Common.MaxEmailLength);

        builder.Property(s => s.ContactPhoneNumber)
            .IsRequired()
            .HasMaxLength(SupplierModelConstants.Common.MaxPhoneNumberLength);

        builder.OwnsOne(s => s.Address, a =>
        {
            a.Property(ad => ad.AddressLine1)
                .IsRequired()
                .HasMaxLength(SupplierModelConstants.Address.MaxAddressLineLength);

            a.Property(ad => ad.AddressLine2)
                .HasMaxLength(SupplierModelConstants.Address.MaxAddressLineLength);

            a.Property(ad => ad.Country)
                .HasMaxLength(SupplierModelConstants.Address.MaxAddressLineLength);

            a.Property(ad => ad.PostalCode)
                .HasMaxLength(SupplierModelConstants.Address.MaxPostalCodeLength);
        });

        builder.HasMany(s => s.Products)
            .WithMany(p => p.Suppliers)
            .UsingEntity<Dictionary<string, object>>(
                "ProductSupplier",
                j => j.HasOne<Product>().WithMany().HasForeignKey("ProductId"),
                j => j.HasOne<Supplier>().WithMany().HasForeignKey("SupplierId"));
    }
}