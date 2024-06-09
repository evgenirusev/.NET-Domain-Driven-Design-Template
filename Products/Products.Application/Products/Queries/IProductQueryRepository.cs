using Common.Application;

public interface IProductQueryRepository : IQueryRepository<Product>
{
    Task<ProductResponse?> GetResponseById(int id, CancellationToken cancellationToken = default);
}