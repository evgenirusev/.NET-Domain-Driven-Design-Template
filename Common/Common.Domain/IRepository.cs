public interface IRepository<in TEntity> where TEntity : IAggregateRoot
{
    Task Save(TEntity entity);
}