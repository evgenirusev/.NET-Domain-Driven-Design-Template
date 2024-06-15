public class Price : ValueObject
{
    public decimal Amount { get; }
    public string Currency { get; }

    public Price(decimal amount, string currency)
    {
        Validate(amount, currency);

        Amount = amount;
        Currency = currency;
    }

    private void Validate(decimal amount, string currency)
    {
        Guard.AgainstOutOfRange(amount, 0, decimal.MaxValue, nameof(amount));
        Guard.AgainstEmptyString(currency, nameof(currency));
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Amount;
        yield return Currency;
    }
}

