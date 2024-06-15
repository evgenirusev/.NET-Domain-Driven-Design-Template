public interface IOrderFactory : IFactory<Order>
{
    IOrderFactory WithCustomerId(int customerId);
    IOrderFactory WithOrderDate(DateTime orderDate);
    Order Build();
}
