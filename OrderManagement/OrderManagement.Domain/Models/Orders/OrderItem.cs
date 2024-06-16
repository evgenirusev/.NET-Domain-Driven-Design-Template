public class OrderItem : Entity
{
    internal OrderItem(Guid orderId, Guid productId, int quantity)
    {
        ValidateQuantity(quantity);

        OrderId = orderId;
        ProductId = productId;
        Quantity = quantity;
    }

    public Guid OrderId { get; private set; }
    public Guid ProductId { get; private set; }
    public int Quantity { get; private set; }

    public OrderItem UpdateProductId(Guid productId)
    {
        ProductId = productId;
        return this;
    }

    public OrderItem UpdateQuantity(int quantity)
    {
        ValidateQuantity(quantity);
        Quantity = quantity;
        return this;
    }

    private void ValidateQuantity(int quantity)
    {
        if (quantity < OrderModelConstants.OrderItem.MinQuantity || quantity > OrderModelConstants.OrderItem.MaxQuantity)
        {
            throw new ArgumentException($"Quantity must be between {OrderModelConstants.OrderItem.MinQuantity} and {OrderModelConstants.OrderItem.MaxQuantity}.");
        }
    }
}