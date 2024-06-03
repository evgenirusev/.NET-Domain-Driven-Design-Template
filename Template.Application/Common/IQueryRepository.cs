using Template.Domain.Common;

namespace Template.Application.Features;

public interface IQueryRepository<in TEntity> where TEntity : IAggregateRoot
{
}