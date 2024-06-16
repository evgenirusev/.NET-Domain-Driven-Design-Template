public interface IDomainRepository<TEntity>
    where TEntity : IAggregateRoot
{
    Task<Guid> Save(TEntity entity, CancellationToken cancellationToken = default);
}