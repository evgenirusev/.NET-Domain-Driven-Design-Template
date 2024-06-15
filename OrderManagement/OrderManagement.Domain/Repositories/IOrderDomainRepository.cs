public interface IOrderDomainRepository : IDomainRepository<Order>
{
    Task<Order> Find(int id, CancellationToken cancellationToken = default);
    Task Delete(int id, CancellationToken cancellationToken = default);
}