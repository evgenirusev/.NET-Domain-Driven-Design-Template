public class Order : Entity, IAggregateRoot
{
    public HashSet<OrderItem> OrderItems { get; private set; }

    public Order(Guid customerId, DateTime orderDate)
    {
        ValidateOrderDate(orderDate);

        CustomerId = customerId;
        OrderDate = orderDate;
        OrderItems = new HashSet<OrderItem>();
        Status = OrderStatus.Pending;
        
        RaiseEvent(new OrderAddedEvent());
    }

    public Guid CustomerId { get; private set; }
    public DateTime OrderDate { get; private set; }
    public OrderStatus Status { get; private set; }

    public Order AddOrderItem(Guid productId, int quantity)
    {
        ValidateOrderItemQuantity(quantity);

        var orderItem = new OrderItem(Id, productId, quantity);
        OrderItems.Add(orderItem);

        return this;
    }

    public Order RemoveOrderItem(Guid orderItemId)
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

    public Order UpdateCustomerId(Guid customerId)
    {
        CustomerId = customerId;
        return this;
    }

    public Order UpdateOrderDate(DateTime orderDate)
    {
        ValidateOrderDate(orderDate);
        OrderDate = orderDate;
        return this;
    }

    public Order UpdateOrderItem(Guid orderItemId, Guid productId, int quantity)
    {
        ValidateOrderItemQuantity(quantity);

        var orderItem = OrderItems.FirstOrDefault(oi => oi.Id == orderItemId);
        if (orderItem != null)
        {
            orderItem.UpdateProductId(productId);
            orderItem.UpdateQuantity(quantity);
        }
        return this;
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
