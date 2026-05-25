using AutoMapper;
using Microsoft.EntityFrameworkCore;

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

    public Task<List<OrderListItem>> GetAll(CancellationToken cancellationToken = default)
        => AllAsNoTracking()
            .Select(o => new OrderListItem
            {
                Id = o.Id,
                CustomerId = o.CustomerId,
                OrderDate = o.OrderDate,
                Status = o.Status.Value,
                Items = o.OrderItems
                    .Select(oi => new OrderListItemEntry
                    {
                        ProductId = oi.ProductId,
                        Quantity = oi.Quantity
                    })
                    .ToList()
            })
            .ToListAsync(cancellationToken);
}
