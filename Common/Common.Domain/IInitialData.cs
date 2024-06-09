public interface IInitialData
{
    Type EntityType { get; }

    IEnumerable<object> GetData();
}