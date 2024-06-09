using Mapster;
using Microsoft.EntityFrameworkCore;

internal class ProductRepository : DataRepository<ProductDbContext, Product>,
    IProductDomainRepository,
    IProductQueryRepository
{
    public ProductRepository(ProductDbContext db) : base(db) { }

    public async Task<Product?> Find(int id, CancellationToken cancellationToken = default)
        => await All()
            .Include(b => b.Suppliers)
            .FirstOrDefaultAsync(b => b.Id == id, cancellationToken);

    public async Task<ProductResponse> GetResponseById(int id, CancellationToken cancellationToken = default)
    => (await AllAsNoTracking()
        .Include(b => b.Suppliers)
        .FirstAsync(b => b.Id == id, cancellationToken))
            .Adapt<ProductResponse>();
}