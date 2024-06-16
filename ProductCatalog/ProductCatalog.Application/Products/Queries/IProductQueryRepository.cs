public interface IProductQueryRepository : IQueryRepository<Product>
{
    Task<ProductResponse> GetDetailsById(Guid id, CancellationToken cancellationToken = default);
}