public interface IOrderDomainRepository : IDomainRepository<Order>
{
    Task<Order> Find(Guid id, CancellationToken cancellationToken = default);
    Task Delete(Guid id, CancellationToken cancellationToken = default);
}