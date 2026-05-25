public class OrderListItem
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public DateTime OrderDate { get; set; }
    public int Status { get; set; }
    public List<OrderListItemEntry> Items { get; set; } = new();
}

public class OrderListItemEntry
{
    public Guid ProductId { get; set; }
    public string? ProductName { get; set; }
    public int Quantity { get; set; }
}
