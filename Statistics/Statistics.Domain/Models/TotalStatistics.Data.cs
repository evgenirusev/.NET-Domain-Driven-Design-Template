public class TotalStatisticsData : IInitialData
{
    public Type EntityType => typeof(TotalStatistics);

    public IEnumerable<object> GetData()
        => new List<TotalStatistics> { new() };
}
