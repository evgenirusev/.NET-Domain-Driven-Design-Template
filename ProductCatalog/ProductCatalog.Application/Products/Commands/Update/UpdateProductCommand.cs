using MediatR;

public class UpdateProductCommand : ProductCommand, IRequest<Result>
{
    public Guid Id { get; set; }
    
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Result>
    {
        private readonly IProductDomainRepository productRepository;

        public UpdateProductCommandHandler(IProductDomainRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<Result> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await productRepository.Find(request.Id, cancellationToken);

            product.UpdateName(request.Name)
                .UpdateDescription(request.Description)
                .UpdateProductType(Enumeration.FromValue<ProductType>(request.ProductType))
                .UpdatePrice(request.Price.Amount, request.Price.Currency)
                .UpdateWeight(request.Weight.Value, request.Weight.Unit);

            await productRepository.Save(product, cancellationToken);

            return Result.Success;
        }
    }
}