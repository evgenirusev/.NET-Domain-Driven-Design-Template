public interface IProductDomainRepository : IDomainRepository<Product>
{
    Task<Product> Find(int id, CancellationToken cancellationToken = default);
}