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
            // TODO: validate CustomerId with an API call

            var order = orderFactory
                .WithOrderDate(request.OrderDate)
                .WithCustomerId(request.CustomerId)
                .Build();

            request.OrderItems.ForEach(orderItem =>
            {
                order.AddOrderItem(orderItem.ProductId, orderItem.Quantity);
            });
            
            await orderRepository.Save(order, cancellationToken);

            return new CreateOrderResponse(order.Id);
        }
    }
}