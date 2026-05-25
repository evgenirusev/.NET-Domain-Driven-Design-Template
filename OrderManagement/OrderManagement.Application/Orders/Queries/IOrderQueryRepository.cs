public interface IOrderQueryRepository : IQueryRepository<Order>
{
    Task<OrderResponse> GetDetailsById(Guid id, CancellationToken cancellationToken = default);

    Task<List<OrderListItem>> GetAll(CancellationToken cancellationToken = default);
}