public interface IProductQueryRepository : IQueryRepository<Product>
{
    Task<ProductResponse> GetDetailsById(int id, CancellationToken cancellationToken = default);
}