public interface IDomainRepository<TEntity>
    where TEntity : IAggregateRoot
{
    Task Save(TEntity entity, CancellationToken cancellationToken = default);
}