using Template.Common;

public class Weight : ValueObject
{
    public decimal Value { get; }
    public string Unit { get; }

    internal Weight(decimal value, string unit)
    {
        Guard.AgainstOutOfRange(value, 0, decimal.MaxValue, nameof(value));
        Guard.AgainstEmptyString(unit, nameof(unit));

        Value = value;
        Unit = unit;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
        yield return Unit;
    }
}
