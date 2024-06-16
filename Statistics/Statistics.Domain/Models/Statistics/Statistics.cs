public class Statistics : Entity, IAggregateRoot
{
    public int TotalOrdersCreated { get; private set; }
    public int TotalProductsCreated { get; private set; }

    public Statistics()
    {
        TotalOrdersCreated = 0;
        TotalProductsCreated = 0;
    }

    public void IncrementTotalOrders()
    {
        TotalOrdersCreated++;
    }
    
    public void IncrementTotalProducts()
    {
        TotalProductsCreated++;
    }
}