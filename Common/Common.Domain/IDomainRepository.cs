public interface IDomainRepository<TEntity>
    where TEntity : IAggregateRoot
{
    Task<int> Save(TEntity entity, CancellationToken cancellationToken = default);
}