using MediatR;

public class UpdateOrderCommand : OrderCommand, IRequest<Result>
{
    public Guid Id { get; set; }
    
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, Result>
    {
        private readonly IOrderDomainRepository orderRepository;

        public UpdateOrderCommandHandler(IOrderDomainRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public async Task<Result> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await orderRepository.Find(request.Id, cancellationToken);

            order.UpdateStatus(Enumeration.FromValue<OrderStatus>(request.Status));

            await orderRepository.Save(order, cancellationToken);

            return Result.Success;
        }
    }
}