internal interface IEventPublisher
{
    Task Publish(IDomainEvent domainEvent);

    Task Publish<TDomainEvent>(TDomainEvent domainEvent, Type domainEventType);
}