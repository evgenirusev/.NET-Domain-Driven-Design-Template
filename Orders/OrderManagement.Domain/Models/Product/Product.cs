public class Product : Entity<int>, IAggregateRoot
{
    public Price Price { get; private set; }
    
    internal Product(Price price)
    {
        Price = price;
    }
}
