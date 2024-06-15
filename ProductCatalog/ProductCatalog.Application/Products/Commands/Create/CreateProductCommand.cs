using MediatR;

public class CreateProductCommand : ProductCommand, IRequest<CreateProductResponse>
{
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
            var product = productFactory
                .WithName(request.Name)
                .WithDescription(request.Description)
                .WithProductType(Enumeration.FromValue<ProductType>(request.ProductType))
                .WithPrice(request.Price.Amount, request.Price.Currency)
                .WithWeight(request.Weight.Value, request.Weight.Unit)
                .Build();

            await productRepository.Save(product, cancellationToken);

            return new CreateProductResponse(product.Id);
        }
    }
}