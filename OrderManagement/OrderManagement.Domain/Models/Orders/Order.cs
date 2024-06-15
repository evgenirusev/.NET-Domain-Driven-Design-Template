public class Order : Entity, IAggregateRoot
{
    public HashSet<OrderItem> OrderItems { get; private set; }

    public Order(Guid customerId, DateTime orderDate)
    {
        ValidateCustomerId(customerId);
        ValidateOrderDate(orderDate);

        CustomerId = customerId;
        OrderDate = orderDate;
        OrderItems = new HashSet<OrderItem>();
        Status = OrderStatus.Pending;
    }

    public Guid CustomerId { get; private set; }
    public DateTime OrderDate { get; private set; }
    public OrderStatus Status { get; private set; }

    public Order AddOrderItem(int productId, int quantity)
    {
        ValidateOrderItemQuantity(quantity);

        var orderItem = new OrderItem(Id, productId, quantity);
        OrderItems.Add(orderItem);

        return this;
    }

    public Order RemoveOrderItem(int orderItemId)
    {
        var orderItem = OrderItems.FirstOrDefault(oi => oi.Id == orderItemId);
        if (orderItem != null)
        {
            OrderItems.Remove(orderItem);
        }
        return this;
    }

    public Order UpdateStatus(OrderStatus status)
    {
        Status = status;
        return this;
    }

    private void ValidateCustomerId(Guid customerId)
    {
        if (customerId.ToString().Length != OrderModelConstants.Order.MinCustomerIdLength)
        {
            throw new ArgumentException("Invalid customer ID length.");
        }
    }

    private void ValidateOrderDate(DateTime orderDate)
    {
        if (orderDate > DateTime.Now)
        {
            throw new ArgumentException("Order date cannot be in the future.");
        }
    }

    private void ValidateOrderItemQuantity(int quantity)
    {
        if (quantity < OrderModelConstants.OrderItem.MinQuantity || quantity > OrderModelConstants.OrderItem.MaxQuantity)
        {
            throw new ArgumentException($"Order item quantity must be between {OrderModelConstants.OrderItem.MinQuantity} and {OrderModelConstants.OrderItem.MaxQuantity}.");
        }
    }
}
