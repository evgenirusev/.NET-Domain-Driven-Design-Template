namespace Common.Application;

public interface IQueryRepository<in TEntity>
    where TEntity : IAggregateRoot
{
}