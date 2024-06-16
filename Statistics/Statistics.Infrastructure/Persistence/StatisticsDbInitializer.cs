internal class StatisticsDbInitializer : DbInitializer
{
    public StatisticsDbInitializer(
        StatisticsDbContext db,
        IEnumerable<IInitialData> initialDataProviders)
        : base(db, initialDataProviders)
    {
    }
}