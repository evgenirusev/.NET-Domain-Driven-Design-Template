internal class ProductDbInitializer : DbInitializer
{
    public ProductDbInitializer(
        ProductDbContext db,
        IEnumerable<IInitialData> initialDataProviders)
        : base(db, initialDataProviders)
    {
    }
}