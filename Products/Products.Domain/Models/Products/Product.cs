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

    private void Validate(string name, string description)
    {
        ValidateCompanyName(name);
        ValidateDescription(description);
    }

    private void ValidateCompanyName(string name)
        => Guard.ForStringLength(name, 2, 50, nameof(Name));

    private void ValidateDescription(string description)
        => Guard.ForStringLength(description, 2, 500, nameof(Description));
}