public interface IProductDomainRepository : IDomainRepository<Product>
{
    Task<Product> GetById(int id, CancellationToken cancellationToken = default);
}