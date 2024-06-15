public class Address : ValueObject
{
    internal Address(string addressLine1, string? addressLine2, string? country, string? postalCode)
    {
        Validate(addressLine1, addressLine2, country, postalCode);
        
        AddressLine1 = addressLine1;
        AddressLine2 = addressLine2;
        Country = country;
        PostalCode = postalCode;
    }

    public string AddressLine1 { get; }
    public string? AddressLine2 { get; }
    public string? Country { get; }
    public string? PostalCode { get; }

    private void Validate(string addressLine1, string? addressLine2, string? country, string? postalCode) 
    {
        Guard.AgainstEmptyString(addressLine1);
        Guard.ForStringLength(AddressLine1, 2, 500, nameof(AddressLine1));
        
        if (!string.IsNullOrWhiteSpace(addressLine2))
            Guard.ForStringLength(AddressLine2, 2, 500, nameof(AddressLine2));
        if (!string.IsNullOrWhiteSpace(addressLine2))
            Guard.ForStringLength(PostalCode, 2, 10, nameof(PostalCode));
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return AddressLine1;
        yield return AddressLine2;
        yield return Country;
        yield return PostalCode;
    }
}