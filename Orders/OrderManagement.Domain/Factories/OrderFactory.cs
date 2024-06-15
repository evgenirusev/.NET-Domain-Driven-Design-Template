internal class OrderFactory : IOrderFactory
{
    private Guid customerId = default!;
    private DateTime orderDate = default!;
    private List<OrderItem> orderItems = new();

    private bool isCustomerIdSet = false;
    private bool isOrderDateSet = false;

    public IOrderFactory WithCustomerId(Guid customerId)
    {
        this.customerId = customerId;
        isCustomerIdSet = true;

        return this;
    }

    public IOrderFactory WithOrderDate(DateTime orderDate)
    {
        this.orderDate = orderDate;
        isOrderDateSet = true;

        return this;
    }

    public IOrderFactory WithOrderItem(int productId, int quantity)
    {
        var orderItem = new OrderItem(productId, quantity);
        orderItems.Add(orderItem);

        return this;
    }

    public Order Build()
    {
        if (!isCustomerIdSet || !isOrderDateSet || !orderItems.Any())
            throw new InvalidOperationException("Customer ID, order date, and at least one order item must have a value.");

        var order = new Order(customerId, orderDate);

        foreach (var orderItem in orderItems)
        {
            order.AddOrderItem(orderItem.ProductId, orderItem.Quantity);
        }

        return order;
    }
}