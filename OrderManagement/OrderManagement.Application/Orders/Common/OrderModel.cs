using AutoMapper;

public class OrderModel : IMapFrom<Order>
{
    public Guid CustomerId { get; set; }
    public DateTime OrderDate { get; set; }
    public int Status { get; private set; }
    public List<OrderItemModel> OrderItems { get; set; } = new();

    public virtual void Mapping(Profile mapper)
    {
        mapper.CreateMap<Order, OrderModel>()
            .ForMember(p => p.Status, opt => opt.MapFrom(src => src.Status.Value));
    }
}
