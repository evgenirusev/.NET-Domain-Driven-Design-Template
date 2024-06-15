using MediatR;

public class CreateOrderCommand : OrderCommand, IRequest<CreateOrderResponse>
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, CreateOrderResponse>
    {
        private readonly IOrderDomainRepository orderRepository;
        private readonly IOrderFactory orderFactory;

        public CreateOrderCommandHandler(
            IOrderDomainRepository orderRepository,
            IOrderFactory orderFactory)
        {
            this.orderRepository = orderRepository;
            this.orderFactory = orderFactory;
        }

        public async Task<CreateOrderResponse> Handle(
            CreateOrderCommand request,
            CancellationToken cancellationToken)
        {
            var order = orderFactory
                .WithOrderDate(request.OrderDate)
                .WithCustomerId(request.CustomerId)
                .Build();

            await orderRepository.Save(order, cancellationToken);

            return new CreateProductResponse(product.Id);
        }
    }
}