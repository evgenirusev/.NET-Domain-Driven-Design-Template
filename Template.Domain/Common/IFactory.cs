using Template.Domain.Common;

public interface IFactory<out TEntity> where TEntity : IAggregateRoot
{
    TEntity Build();
}