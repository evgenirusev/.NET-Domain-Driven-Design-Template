public interface IStatisticsDomainRepository : IDomainRepository<Statistics>
{
    Task IncrementOrders(CancellationToken cancellationToken = default);
    Task IncrementProducts(CancellationToken cancellationToken = default);
}