public record PriceRequest(decimal Amount, string Currency);

public record WeightRequest(decimal Value, string Unit);

public abstract class ProductModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int ProductType { get; set; }
    public PriceRequest Price { get; set; }
    public WeightRequest Weight { get; set; }
}