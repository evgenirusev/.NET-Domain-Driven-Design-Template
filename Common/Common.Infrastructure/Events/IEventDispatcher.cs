internal interface IEventDispatcher
{
    Task Dispatch(IDomainEvent domainEvent);
}