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

    public async Task<Product?> Find(int id, CancellationToken cancellationToken = default)
        => await All()
            .Include(b => b.Suppliers)
            .FirstOrDefaultAsync(b => b.Id == id, cancellationToken);

    public async Task<ProductResponse> GetDetailsById(int id, CancellationToken cancellationToken = default)
        => await mapper
            .ProjectTo<ProductResponse>(AllAsNoTracking()
                .Include(b => b.Suppliers)).FirstAsync();
}