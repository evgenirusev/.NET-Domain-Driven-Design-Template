using Template.Common;

public class Product : Entity<int>, IAggregateRoot
{
    internal Product(
        string name,
        ProductType productType,
        Weight weight)
    {
        Validate(name);
        Name = name;
        Weight = weight;
    }

    public string Name { get; private set; }
    public ProductType ProductType { get; private set; }
    public Weight Weight { get; private set; }

    private void Validate(string name)
    {
        ValidateCompanyName(name);
    }
    
    private void ValidateCompanyName(string name)
        => Guard.ForStringLength(
            name,
            2,
            50,
            nameof(Name));
}