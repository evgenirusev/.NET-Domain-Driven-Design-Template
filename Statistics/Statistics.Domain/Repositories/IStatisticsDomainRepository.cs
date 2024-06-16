public interface IStatisticsDomainRepository : IDomainRepository<TotalStatistics>
{
    Task IncrementOrders(CancellationToken cancellationToken = default);
    Task IncrementProducts(CancellationToken cancellationToken = default);
}