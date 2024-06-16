internal class ProductDbInitializer : DbInitializer
{
    public ProductDbInitializer(
        StatisticsDbContext db,
        IEnumerable<IInitialData> initialDataProviders)
        : base(db, initialDataProviders)
    {
    }
}