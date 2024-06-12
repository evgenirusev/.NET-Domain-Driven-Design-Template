using MediatR;

public class ProductDetailsQuery : EntityCommand<int>, IRequest<ProductResponse>
{
    public class BetDetailsQueryHandler : IRequestHandler<ProductDetailsQuery, ProductResponse>
    {
        private readonly IProductQueryRepository productRepository;

        public BetDetailsQueryHandler(IProductQueryRepository productRepository)
            => this.productRepository = productRepository;

        public async Task<ProductResponse> Handle(
            ProductDetailsQuery request,
            CancellationToken cancellationToken)
            => await productRepository.GetDetailsById(
                request.Id,
                cancellationToken);
    }
}