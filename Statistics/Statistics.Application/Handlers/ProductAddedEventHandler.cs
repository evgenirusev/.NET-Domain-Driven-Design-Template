public class ProductAddedEventHandler : IEventHandler<ProductAddedEvent>
{
    private readonly IStatisticsDomainRepository statistics;

    public ProductAddedEventHandler(IStatisticsDomainRepository statistics) 
        => this.statistics = statistics;

    public Task Handle(ProductAddedEvent domainEvent)
        => statistics.IncrementProducts();
}