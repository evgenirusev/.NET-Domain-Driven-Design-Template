public class OrderAddedEventHandler : IEventHandler<OrderAddedEvent>
{
    private readonly IStatisticsDomainRepository statistics;

    public OrderAddedEventHandler(IStatisticsDomainRepository statistics) 
        => this.statistics = statistics;

    public Task Handle(OrderAddedEvent domainEvent)
        => statistics.IncrementProducts();
}