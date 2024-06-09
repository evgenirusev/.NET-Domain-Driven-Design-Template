using System.Reflection;
using Microsoft.EntityFrameworkCore;

internal abstract class DbInitializer : IDbInitializer
{
    private readonly DbContext db;
    private readonly IEnumerable<IInitialData> initialDataProviders;

    protected internal DbInitializer(DbContext db)
    {
        this.db = db;
        this.initialDataProviders = new List<IInitialData>();
    }

    protected internal DbInitializer(
        DbContext db,
        IEnumerable<IInitialData> initialDataProviders)
        : this(db)
        => this.initialDataProviders = initialDataProviders;

    public virtual void Initialize()
    {
        this.db.Database.Migrate();

        foreach (var initialDataProvider in this.initialDataProviders)
        {
            if (this.DataSetIsEmpty(initialDataProvider.EntityType))
            {
                var data = initialDataProvider.GetData();

                foreach (var entity in data)
                {
                    this.db.Add(entity);
                }
            }
        }

        this.db.SaveChanges();
    }

    private bool DataSetIsEmpty(Type type)
    {
        var setMethod = typeof(DbInitializer)
            .GetMethod(nameof(this.GetSet), BindingFlags.Instance | BindingFlags.NonPublic)!
            .MakeGenericMethod(type);

        var set = setMethod.Invoke(this, Array.Empty<object>());

        var countMethod = typeof(Queryable)
            .GetMethods()
            .First(m => m.Name == nameof(Queryable.Count) && m.GetParameters().Length == 1)
            .MakeGenericMethod(type);

        var result = (int)countMethod.Invoke(null, new[] { set })!;

        return result == 0;
    }

    private DbSet<TEntity> GetSet<TEntity>()
        where TEntity : class
        => this.db.Set<TEntity>();
}