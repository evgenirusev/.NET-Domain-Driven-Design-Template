public interface IOrderFactory : IFactory<Order>
{
    IOrderFactory WithCustomerId(Guid customerId);
    IOrderFactory WithOrderDate(DateTime orderDate);
    IOrderFactory WithOrderItem(int productId, int quantity);
    Order Build();
}
