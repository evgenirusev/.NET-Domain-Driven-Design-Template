public class OrderStatus : Enumeration
{
    public static readonly OrderStatus Pending = new(1, nameof(Pending));
    public static readonly OrderStatus Processing = new(2, nameof(Processing));
    public static readonly OrderStatus Shipped = new(3, nameof(Shipped));
    public static readonly OrderStatus Delivered = new(4, nameof(Delivered));
    public static readonly OrderStatus Cancelled = new(5, nameof(Cancelled));

    private OrderStatus(int value, string name)
        : base(value, name)
    {
    }

    private OrderStatus(int value)
        : this(value, FromValue<OrderStatus>(value).Name)
    {
    }
}