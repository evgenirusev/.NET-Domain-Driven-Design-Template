public interface IEventDispatcher
{
    Task Dispatch(IDomainEvent domainEvent);
}