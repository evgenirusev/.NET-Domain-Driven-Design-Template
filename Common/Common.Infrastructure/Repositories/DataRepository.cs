using Microsoft.EntityFrameworkCore;

public abstract class DataRepository<TDbContext, TEntity> : IDomainRepository<TEntity>
    where TDbContext : DbContext
    where TEntity : Entity, IAggregateRoot
{
    protected DataRepository(TDbContext db) => Data = db;

    protected TDbContext Data { get; }

    protected IQueryable<TEntity> All() => Data.Set<TEntity>();

    protected IQueryable<TEntity> AllAsNoTracking() => All().AsNoTracking();

    public async Task Save(
        TEntity entity,
        CancellationToken cancellationToken = default)
    {
        Data.Update(entity);
        await Data.SaveChangesAsync(cancellationToken);
    }
}
