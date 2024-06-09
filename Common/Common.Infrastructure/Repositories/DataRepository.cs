using Microsoft.EntityFrameworkCore;

internal abstract class DataRepository<TDbContext, TEntity> : IDomainRepository<TEntity>
    where TDbContext : DbContext
    where TEntity : class, IAggregateRoot
{
    protected DataRepository(TDbContext db) => this.Data = db;

    protected TDbContext Data { get; }

    protected IQueryable<TEntity> All() => this.Data.Set<TEntity>();

    protected IQueryable<TEntity> AllAsNoTracking() => this.All().AsNoTracking();

    public async Task Save(
        TEntity entity,
        CancellationToken cancellationToken = default)
    {
        this.Data.Update(entity);

        await this.Data.SaveChangesAsync(cancellationToken);
    }
}