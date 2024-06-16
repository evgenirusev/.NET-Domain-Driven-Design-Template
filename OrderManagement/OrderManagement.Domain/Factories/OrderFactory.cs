internal class OrderFactory : IOrderFactory
{
    private Guid customerId = default!;
    private DateTime orderDate = default!;

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

    public Order Build()
    {
        if (!isCustomerIdSet || !isOrderDateSet)
            throw new InvalidOperationException("Customer ID, order date must have a value.");

        return new Order(customerId, orderDate);
    }
}