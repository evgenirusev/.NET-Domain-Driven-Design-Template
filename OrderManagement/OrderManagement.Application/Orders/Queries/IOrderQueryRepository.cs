public interface IOrderQueryRepository : IQueryRepository<Order>
{
    Task<OrderResponse> GetDetailsById(Guid id, CancellationToken cancellationToken = default);
}