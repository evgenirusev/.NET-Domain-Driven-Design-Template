internal class OrderData // : IInitialData
{
    public Type EntityType => typeof(Order);

    public IEnumerable<object> GetData()
    {
        var order1 = new Order(
            customerId: new Guid(),
            orderDate: DateTime.Now.AddDays(-5)
        );

        order1.AddOrderItem(
            productId: new Guid(),
            quantity: 2
        );

        order1.AddOrderItem(
            productId: new Guid(),
            quantity: 5
        );

        var order2 = new Order(
            customerId: new Guid(),
            orderDate: DateTime.Now.AddDays(-3)
        );

        order2.AddOrderItem(
            productId: new Guid(),
            quantity: 10
        );

        return new List<Order> { order1, order2 };
    }
}