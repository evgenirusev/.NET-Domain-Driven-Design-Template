using MediatR;

public class UpdateProductCommand : IRequest<Unit>
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
            return Unit.Value;
        }
    }
}