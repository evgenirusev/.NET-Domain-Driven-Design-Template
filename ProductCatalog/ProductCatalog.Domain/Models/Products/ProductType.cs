public class ProductType : Enumeration
{
    public static ProductType Electronics = new(1, nameof(Electronics));
    public static ProductType Clothing = new(2, nameof(Clothing));
    public static ProductType Books = new(3, nameof(Books));
    public static ProductType HomeAppliances = new(4, nameof(HomeAppliances));

    private ProductType(int value, string name) 
        : base(value, name)
    {
    }
    
    private ProductType(int value)
        : this(value, FromValue<ProductType>(value).Name)
    {
    }
}