internal class OrderData
{
    public Type EntityType => typeof(Order);

    public IEnumerable<object> GetData()
    {
        var order1 = new Order(
            customerId: Guid.NewGuid(),
            orderDate: DateTime.Now.AddDays(-5)
        );

        order1.AddOrderItem(
            productId: 1,
            quantity: 2
        );

        order1.AddOrderItem(
            productId: 2,
            quantity: 5
        );

        var order2 = new Order(
            customerId: Guid.NewGuid(),
            orderDate: DateTime.Now.AddDays(-3)
        );

        order2.AddOrderItem(
            productId: 3,
            quantity: 10
        );

        return new List<Order> { order1, order2 };
    }
}