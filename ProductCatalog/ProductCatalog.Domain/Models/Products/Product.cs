public class Product : Entity, IAggregateRoot
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
        
        RaiseEvent(new ProductAddedEvent());
    }
    
    private Product(
        string name,
        string description)
    {
        Validate(name, description);
        Name = name;
        Description = description;
        ProductType = default!;
        Weight = default!;
        Price = default!;

        Suppliers = default!;
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
        => Guard.ForStringLength(name, ProductModelConstants.Product.MinNameLength, ProductModelConstants.Product.MaxNameLength, nameof(Name));

    private void ValidateDescription(string description)
        => Guard.ForStringLength(description, ProductModelConstants.Product.MinDescriptionLength, ProductModelConstants.Product.MaxDescriptionLength, nameof(Description));
}
