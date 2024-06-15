using MediatR;

public class DeleteProductCommand : EntityCommand, IRequest<Result>
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Result>
    {
        private readonly IProductDomainRepository productRepository;

        public DeleteProductCommandHandler(IProductDomainRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<Result> Handle(
            DeleteProductCommand request, 
            CancellationToken cancellationToken)
        {
            await productRepository.Delete(
                request.Id,
                cancellationToken);

            return Result.Success;
        }
    }
}