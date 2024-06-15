public class CreateOrderResponse
{
    public CreateOrderResponse(int orderId)
    {
        OrderId = orderId;
    }

    public int OrderId { get; }
}