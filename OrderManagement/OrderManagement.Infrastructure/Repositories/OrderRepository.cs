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

    public Task<Order?> Find(Guid id, CancellationToken cancellationToken = default)
        => All()
            .Include(o => o.OrderItems)
            .FirstOrDefaultAsync(o => o.Id == id, cancellationToken);

    public async Task Delete(Guid id, CancellationToken cancellationToken = default)
    {
        var order = await Find(id, cancellationToken);

        if (order == null)
        {
            throw new NotFoundException(nameof(Order), id);
        }

        Data.Set<Order>().Remove(order);

        await Data.SaveChangesAsync(cancellationToken);
    }

    public Task<OrderResponse> GetDetailsById(Guid id, CancellationToken cancellationToken = default)
        => _mapper
            .ProjectTo<OrderResponse>(AllAsNoTracking().Where(o => o.Id == id))
            .FirstAsync(cancellationToken);

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
