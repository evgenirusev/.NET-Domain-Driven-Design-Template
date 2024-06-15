using OrderManagement.Application.Orders.Common;

public class OrderModel
{
    public Guid CustomerId { get; set; }
    public DateTime OrderDate { get; set; }
    public List<OrderItemModel> OrderItems { get; set; } = new();
}
