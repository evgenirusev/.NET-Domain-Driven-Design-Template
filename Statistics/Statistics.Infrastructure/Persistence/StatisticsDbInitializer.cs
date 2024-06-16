internal class StatisticsDbInitializer : DbInitializer
{
    public StatisticsDbInitializer(
        StatisticsDbContext db)
        : base(db, new List<IInitialData> { new TotalStatisticsData() })
    {
    }
}