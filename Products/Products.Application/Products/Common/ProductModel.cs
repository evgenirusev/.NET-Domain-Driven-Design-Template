using AutoMapper;

public record PriceRequest(decimal Amount, string Currency);

public record WeightRequest(decimal Value, string Unit);

public class ProductModel : IMapFrom<Product>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int ProductType { get; set; }
    public PriceRequest Price { get; set; }
    public WeightRequest Weight { get; set; }

    public virtual void Mapping(Profile mapper)
    {
        mapper.CreateMap<Product, ProductModel>()
            .ForMember(p => p.ProductType, opt => opt.MapFrom(src => src.ProductType.Value))
            .ForMember(p => p.Price, opt => opt.MapFrom(src => new PriceRequest(src.Price.Amount, src.Price.Currency)))
            .ForMember(p => p.Weight, opt => opt.MapFrom(src => new WeightRequest(src.Weight.Value, src.Weight.Unit)));
    }
}