using AutoMapper;
using Microsoft.EntityFrameworkCore;

internal class ProductRepository : DataRepository<ProductDbContext, Product>,
    IProductDomainRepository,
    IProductQueryRepository
{
    private readonly IMapper mapper;

    public ProductRepository(ProductDbContext db, IMapper mapper)
        : base(db)
        => this.mapper = mapper;

    public async Task<Product?> Find(Guid id, CancellationToken cancellationToken = default)
        => await All()
            .Include(b => b.Suppliers)
            .FirstOrDefaultAsync(b => b.Id == id, cancellationToken);

    public async Task<ProductResponse> GetDetailsById(Guid id, CancellationToken cancellationToken = default)
    {
        var response = await mapper
            .ProjectTo<ProductResponse>(AllAsNoTracking().Where(b => b.Id == id))
            .FirstOrDefaultAsync(cancellationToken);

        if (response == null)
        {
            throw new NotFoundException(nameof(Product), id);
        }

        return response;
    }

    public async Task Delete(Guid id, CancellationToken cancellationToken = default)
    {
        var product = await Find(id, cancellationToken);

        if (product == null)
        {
            throw new NotFoundException(nameof(Product), id);
        }

        Data.Set<Product>().Remove(product);

        await Data.SaveChangesAsync(cancellationToken);
    }
}