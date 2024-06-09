using MassTransit;

internal class EventPublisher : IEventPublisher
{
    private const int TimeoutMilliseconds = 2000;

    private readonly IBus bus;

    public EventPublisher(IBus bus)
        => this.bus = bus;

    public async Task Publish(IDomainEvent domainEvent)
        => await this.bus.Publish(
            domainEvent,
            domainEvent.GetType(),
            GetCancellationToken());

    public async Task Publish<TDomainEvent>(TDomainEvent domainEvent, Type domainEventType)
        => await this.bus.Publish(
            domainEvent,
            domainEventType,
            GetCancellationToken());

    private static CancellationToken GetCancellationToken()
    {
        var timeout = TimeSpan.FromMilliseconds(TimeoutMilliseconds);
        var cancellationTokenSource = new CancellationTokenSource(timeout);

        return cancellationTokenSource.Token;
    }
}