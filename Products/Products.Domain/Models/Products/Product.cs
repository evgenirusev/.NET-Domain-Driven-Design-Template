public class Product : Entity<int>, IAggregateRoot
{
    public HashSet<Supplier> Suppliers { get; private set; }

    internal Product(
        string name,
        string description,
        ProductType productType,
        Weight weight,
        Price price)
    {
        Validate(name, description);
        Name = name;
        Description = description;
        ProductType = productType;
        Weight = weight;
        Price = price;

        Suppliers = new HashSet<Supplier>();
    }

    public string Name { get; private set; }
    public string Description { get; private set; }
    public ProductType ProductType { get; private set; }
    public Weight Weight { get; private set; }
    public Price Price { get; private set; }

    public Product UpdateName(string name)
    {
        ValidateName(name);
        Name = name;
        return this;
    }

    public Product UpdateDescription(string description)
    {
        ValidateDescription(description);
        Description = description;
        return this;
    }

    public Product UpdateProductType(ProductType productType)
    {
        ProductType = productType;
        return this;
    }

    public Product UpdateWeight(decimal value, string unit)
    {
        Weight = new Weight(value, unit);
        return this;
    }

    public Product UpdatePrice(decimal amount, string currency)
    {
        Price = new Price(amount, currency);
        return this;
    }

    public Product AddSupplier(Supplier supplier)
    {
        Suppliers.Add(supplier);
        return this;
    }

    public Product RemoveSupplier(Supplier supplier)
    {
        Suppliers.Remove(supplier);
        return this;
    }

    private void Validate(string name, string description)
    {
        ValidateName(name);
        ValidateDescription(description);
    }

    private void ValidateName(string name)
        => Guard.ForStringLength(name, ProductModelConstants.Common.MinNameLength, ProductModelConstants.Common.MaxNameLength, nameof(Name));

    private void ValidateDescription(string description)
        => Guard.ForStringLength(description, ProductModelConstants.Common.MinDescriptionLength, ProductModelConstants.Common.MaxDescriptionLength, nameof(Description));
}
