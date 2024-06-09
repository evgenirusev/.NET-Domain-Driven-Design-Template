public abstract class Entity<TId> : IEntity
    where TId : struct
{
    private readonly ICollection<IDomainEvent> events;

    protected Entity() => events = new List<IDomainEvent>();

    public TId Id { get; private set; } = default;

    public IReadOnlyCollection<IDomainEvent> Events
        => events.ToList().AsReadOnly();

    public void ClearEvents() => events.Clear();

    protected void RaiseEvent(IDomainEvent domainEvent)
        => events.Add(domainEvent);

    public override bool Equals(object? obj)
    {
        if (obj is not Entity<TId> other)
        {
            return false;
        }

        if (ReferenceEquals(this, other))
        {
            return true;
        }

        if (GetType() != other.GetType())
        {
            return false;
        }

        if (Id.Equals(default) || other.Id.Equals(default))
        {
            return false;
        }

        return Id.Equals(other.Id);
    }

    public static bool operator ==(Entity<TId>? first, Entity<TId>? second)
    {
        if (first is null && second is null)
        {
            return true;
        }

        if (first is null || second is null)
        {
            return false;
        }

        return first.Equals(second);
    }

    public static bool operator !=(Entity<TId>? first, Entity<TId>? second) => !(first == second);

    public override int GetHashCode() => (GetType().ToString() + Id).GetHashCode();
}