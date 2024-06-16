public class TotalStatistics : Entity, IAggregateRoot
{
    public int TotalOrdersCreated { get; private set; }
    public int TotalProductsCreated { get; private set; }

    public TotalStatistics()
    {
        TotalOrdersCreated = 0;
        TotalProductsCreated = 0;
    }

    private TotalStatistics(int totalOrdersCreated, int totalProductsCreated)
    {
        TotalOrdersCreated = totalOrdersCreated;
        TotalProductsCreated = totalProductsCreated;
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