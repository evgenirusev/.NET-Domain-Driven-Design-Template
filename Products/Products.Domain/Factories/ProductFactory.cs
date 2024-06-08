internal class ProductFactory : IProductFactory
{
    private string productName = default!;
    private string productDescription = default!;
    private ProductType productType = default!;
    private Price productPrice = default!;
    private Weight productWeight = default!;

    private bool isNameSet = false;
    private bool isDescriptionSet = false;
    private bool isProductTypeSet = false;
    private bool isPriceSet = false;
    private bool isWeightSet = false;

    public IProductFactory WithName(string name)
    {
        this.productName = name;
        this.isNameSet = true;

        return this;
    }

    public IProductFactory WithDescription(string description)
    {
        this.productDescription = description;
        this.isDescriptionSet = true;

        return this;
    }

    public IProductFactory WithProductType(ProductType productType)
    {
        this.productType = productType;
        this.isProductTypeSet = true;

        return this;
    }

    public IProductFactory WithPrice(decimal price, string unit)
    {
        this.productPrice = new Price(price, unit);
        this.isPriceSet = true;

        return this;
    }

    public IProductFactory WithWeight(decimal weight, string unit)
    {
        this.productWeight = new Weight(weight, unit);
        this.isWeightSet = true;

        return this;
    }

    public Product Build()
    {
        if (!this.isNameSet || !this.isDescriptionSet || !this.isProductTypeSet || !this.isPriceSet || !this.isWeightSet)
            throw new InvalidOperationException("Name, description, product type, price, and weight must have a value.");

        return new Product(
            this.productName,
            this.productDescription,
            this.productType,
            this.productWeight,
            this.productPrice);
    }
}