using AutoMapper;

public class ProductResponse : ProductModel
{
    public override void Mapping(Profile mapper)
        => mapper
            .CreateMap<Product, ProductResponse>()
            .IncludeBase<Product, ProductModel>();
}