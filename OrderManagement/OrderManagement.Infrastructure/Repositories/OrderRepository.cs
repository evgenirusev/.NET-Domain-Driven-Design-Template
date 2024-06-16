using AutoMapper;

internal class OrderRepository : DataRepository<OrderManagementDbContext, Order>,
    IOrderDomainRepository,
    IOrderQueryRepository
{
    private readonly IMapper mapper;

    public OrderRepository(OrderManagementDbContext db, IMapper mapper)
        : base(db)
        => this.mapper = mapper;
    
    public Task<Order> Find(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task Delete(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<OrderResponse> GetDetailsById(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}