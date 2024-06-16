internal class ProductDbInitializer : DbInitializer
{
    public ProductDbInitializer(ProductDbContext db) 
        : base(db, new List<IInitialData> { new ProductData() }) {}
}
