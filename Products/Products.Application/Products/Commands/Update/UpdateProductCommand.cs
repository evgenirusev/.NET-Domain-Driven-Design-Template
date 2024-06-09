using MediatR;

public class UpdateProductCommand : ProductCommand, IRequest<Unit>
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Unit>
    {
        private readonly IProductDomainRepository productRepository;

        public UpdateProductCommandHandler(IProductDomainRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await productRepository.Find(request.Id, cancellationToken);

            product.UpdateName(request.Name)
                .UpdateDescription(request.Description)
                .UpdateProductType(Enumeration.FromValue<ProductType>(request.ProductType))
                .UpdatePrice(request.Price.Amount, request.Price.Currency)
                .UpdateWeight(request.Weight.Value, request.Weight.Unit);

            await productRepository.Save(product, cancellationToken);

            return Unit.Value;
        }
    }
}