public class ProductCommand : EntityCommand<int>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int ProductType { get; set; }
    public CreatePriceRequest Price { get; set; }
    public CreateWeightRequest Weight { get; set; }
}