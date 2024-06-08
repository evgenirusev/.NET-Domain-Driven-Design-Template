using Template.Common;

public interface IDomainRepository<in TEntity>
    where TEntity : IAggregateRoot
{
    Task Save(TEntity entity, CancellationToken cancellationToken = default);
}