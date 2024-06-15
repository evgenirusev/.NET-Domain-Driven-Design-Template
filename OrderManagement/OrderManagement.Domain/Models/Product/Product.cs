public class Product : Entity, IAggregateRoot
{
    public Price Price { get; private set; }
    
    internal Product(Price price)
    {
        Price = price;
    }
}
