using MediatR;

public class ProductDetailsQuery : EntityCommand, IRequest<ProductResponse>
{
    public class ProductDetailsQueryHandler : IRequestHandler<ProductDetailsQuery, ProductResponse>
    {
        private readonly IProductQueryRepository productRepository;

        public ProductDetailsQueryHandler(IProductQueryRepository productRepository)
            => this.productRepository = productRepository;

        public async Task<ProductResponse> Handle(
            ProductDetailsQuery request,
            CancellationToken cancellationToken)
            => await productRepository.GetDetailsById(
                request.Id,
                cancellationToken);
    }
}