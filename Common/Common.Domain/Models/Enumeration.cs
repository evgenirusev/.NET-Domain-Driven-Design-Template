using System.Collections.Concurrent;
using System.Reflection;

public abstract class Enumeration : IComparable
{
    private static readonly ConcurrentDictionary<Type, IEnumerable<object>> EnumCache = new();

    protected Enumeration(int value, string name)
    {
        this.Value = value;
        this.Name = name;
    }

    public int Value { get; }

    public string Name { get; }

    public int CompareTo(object? other) => this.Value.CompareTo(((Enumeration)other!).Value);

    public static IEnumerable<T> GetAll<T>() where T : Enumeration
    {
        var type = typeof(T);

        var values = EnumCache.GetOrAdd(type, _ => type
            .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)
            .Select(f => f.GetValue(null)!));

        return values.Cast<T>();
    }

    public static T FromValue<T>(int value) where T : Enumeration
        => Parse<T, int>(value, nameof(value), item => item.Value == value);

    public static T FromName<T>(string name) where T : Enumeration
        => Parse<T, string>(name, nameof(name), item => item.Name == name);

    public static string NameFromValue<T>(int value) where T : Enumeration
        => FromValue<T>(value).Name;

    public static bool HasValue<T>(int value) where T : Enumeration
    {
        try
        {
            FromValue<T>(value);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Enumeration otherValue)
        {
            return false;
        }

        var typeMatches = this.GetType() == obj.GetType();
        var valueMatches = this.Value.Equals(otherValue.Value);

        return typeMatches && valueMatches;
    }

    public override string ToString() => this.Name;

    public override int GetHashCode() => (this.GetType().ToString() + this.Value).GetHashCode();

    public static bool operator ==(Enumeration? first, Enumeration? second)
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

    public static bool operator !=(Enumeration? first, Enumeration? second) => !(first == second);

    private static T Parse<T, TValue>(TValue value, string description, Func<T, bool> predicate)
        where T : Enumeration
    {
        var matchingItem = GetAll<T>().FirstOrDefault(predicate);

        if (matchingItem == null)
        {
            throw new InvalidOperationException($"'{value}' is not a valid {description} in {typeof(T)}");
        }

        return matchingItem;
    }
}