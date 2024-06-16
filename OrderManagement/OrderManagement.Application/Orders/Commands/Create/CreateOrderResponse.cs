public class CreateOrderResponse
{
    public CreateOrderResponse(Guid orderId)
    {
        OrderId = orderId;
    }

    public Guid OrderId { get; }
}