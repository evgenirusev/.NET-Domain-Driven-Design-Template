public class ProductData : IInitialData
{
    public Type EntityType => typeof(Product);

    public IEnumerable<object> GetData()
    {
        var product1 = new Product(
            name: "Product 1",
            description: "Description of Product 1",
            productType: ProductType.Electronics,
            weight: new Weight(2.5m, "kg"),
            price: new Price(499.99m, "USD")
        );

        var product2 = new Product(
            name: "Product 2",
            description: "Description of Product 2",
            productType: ProductType.Clothing,
            weight: new Weight(0.5m, "kg"),
            price: new Price(29.99m, "USD")
        );

        return new List<Product> { product1, product2 };
    }
}
