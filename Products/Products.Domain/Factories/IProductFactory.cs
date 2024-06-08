public interface IProductFactory : IFactory<Product>
{
    IProductFactory WithName(string name);
    IProductFactory WithDescription(string description);
    IProductFactory WithProductType(ProductType productType);
    IProductFactory WithPrice(decimal amount, string currency);
    IProductFactory WithWeight(decimal value, string unit);
}