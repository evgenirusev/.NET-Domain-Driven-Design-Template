using MediatR;

public class OrderDetailsQuery : EntityCommand, IRequest<OrderResponse>
{
    public class OrderDetailsQueryHandler : IRequestHandler<OrderDetailsQuery, OrderResponse>
    {
        private readonly IOrderQueryRepository orderRepository;

        public OrderDetailsQueryHandler(IOrderQueryRepository orderRepository)
            => this.orderRepository = orderRepository;

        public async Task<OrderResponse> Handle(
            OrderDetailsQuery request,
            CancellationToken cancellationToken)
            => await orderRepository.GetDetailsById(
                request.Id,
                cancellationToken);
    }
}