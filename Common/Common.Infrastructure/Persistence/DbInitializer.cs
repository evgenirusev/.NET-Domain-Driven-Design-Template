using System.Reflection;
using Microsoft.EntityFrameworkCore;

public abstract class DbInitializer : IDbInitializer
{
    private readonly DbContext db;
    private readonly IEnumerable<IInitialData> initialDataProviders;

    protected internal DbInitializer(DbContext db)
    {
        this.db = db;
        initialDataProviders = new List<IInitialData>();
    }

    protected internal DbInitializer(
        DbContext db,
        IEnumerable<IInitialData> initialDataProviders)
        : this(db)
        => this.initialDataProviders = initialDataProviders;

    public virtual void Initialize()
    {
        db.Database.Migrate();

        foreach (var initialDataProvider in initialDataProviders)
        {
            if (DataSetIsEmpty(initialDataProvider.EntityType))
            {
                var data = initialDataProvider.GetData();
            
                foreach (var entity in data)
                {
                    db.Add(entity);
                }
            }
        }

        db.SaveChanges();
    }

    private bool DataSetIsEmpty(Type type)
    {
        var setMethod = typeof(DbInitializer)
            .GetMethod(nameof(GetSet), BindingFlags.Instance | BindingFlags.NonPublic)!
            .MakeGenericMethod(type);

        var set = setMethod.Invoke(this, Array.Empty<object>());

        var countMethod = typeof(Queryable)
            .GetMethods()
            .First(m => m.Name == nameof(Queryable.Count) && m.GetParameters().Length == 1)
            .MakeGenericMethod(type);

        var result = (int)countMethod.Invoke(null, [set])!;

        return result == 0;
    }

    private DbSet<TEntity> GetSet<TEntity>()
        where TEntity : class
        => db.Set<TEntity>();
}