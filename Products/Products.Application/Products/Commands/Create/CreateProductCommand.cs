using MediatR;
using Template.Domain.Repositories;

public record CreatePriceRequest(decimal Amount, string Currency);
public record CreateWeightRequest(decimal Value, string Unit);

public class CreateProductCommand : IRequest<CreateProductResponse>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int ProductType { get; set; }
    public CreatePriceRequest Price { get; set; }
    public CreateWeightRequest Weight { get; set; }

    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductResponse>
    {
        private readonly IProductDomainRepository productRepository;
        private readonly IProductFactory productFactory;

        public CreateProductCommandHandler(
            IProductDomainRepository productRepository,
            IProductFactory productFactory)
        {
            this.productRepository = productRepository;
            this.productFactory = productFactory;
        }

        public async Task<CreateProductResponse> Handle(
            CreateProductCommand request,
            CancellationToken cancellationToken)
        {
            var productType = Enumeration.FromValue<ProductType>(request.ProductType);

            var product = productFactory
                .WithName(request.Name)
                .WithDescription(request.Description)
                .WithProductType(productType)
                .WithPrice(request.Price.Amount, request.Price.Currency)
                .WithWeight(request.Weight.Value, request.Weight.Unit)
                .Build();

            await productRepository.Save(product, cancellationToken);

            return new CreateProductResponse(product.Id);
        }
    }
}