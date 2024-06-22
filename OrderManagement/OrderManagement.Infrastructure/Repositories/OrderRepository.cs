using AutoMapper;

internal class OrderRepository : DataRepository<OrderManagementDbContext, Order>,
    IOrderDomainRepository,
    IOrderQueryRepository
{
    private readonly IMapper _mapper;

    public OrderRepository(OrderManagementDbContext db, IMapper mapper)
        : base(db)
    {
        _mapper = mapper;
    }

    public Task<Order> Find(Guid id, CancellationToken cancellationToken = default)
    {
        // Implementation here
        throw new NotImplementedException();
    }

    public Task Delete(Guid id, CancellationToken cancellationToken = default)
    {
        // Implementation here
        throw new NotImplementedException();
    }

    public Task<OrderResponse> GetDetailsById(Guid id, CancellationToken cancellationToken = default)
    {
        // Implementation here
        throw new NotImplementedException();
    }
}
