public interface IOrderQueryRepository : IQueryRepository<Order>
{
    Task<OrderResponse> GetDetailsById(int id, CancellationToken cancellationToken = default);
}