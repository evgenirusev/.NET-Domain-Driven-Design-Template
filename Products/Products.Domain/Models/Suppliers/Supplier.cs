public class Supplier : Entity<int>, IAggregateRoot
{
    internal Supplier(
        string name,
        string contactEmail,
        string contactPhoneNumber,
        Address address)
    {
        Validate(name, contactEmail, contactPhoneNumber);

        Name = name;
        ContactEmail = contactEmail;
        ContactPhoneNumber = contactPhoneNumber;
        Address = address;
        Products = new HashSet<Product>();
    }

    public string Name { get; private set; }
    public string ContactEmail { get; private set; }
    public string ContactPhoneNumber { get; private set; }
    public Address Address { get; private set; }
    public HashSet<Product> Products { get; private set; }

    private void Validate(string name, string contactEmail, string contactPhoneNumber)
    {
        ValidateCompanyName(name);
        ValidateContactEmail(contactEmail);
        ValidateContactPhoneNumber(contactPhoneNumber);
    }

    private void ValidateCompanyName(string name)
        => Guard.ForStringLength(name, 2, 50, nameof(Name));

    private void ValidateContactEmail(string contactEmail)
    {
        // Add your email validation logic here
        // For simplicity, this example just checks for null or empty string
        if (string.IsNullOrEmpty(contactEmail))
            throw new ArgumentNullException(nameof(ContactEmail), "Contact email cannot be null or empty.");
    }

    private void ValidateContactPhoneNumber(string contactPhoneNumber)
    {
        // Add your phone number validation logic here
        // For simplicity, this example just checks for null or empty string
        if (string.IsNullOrEmpty(contactPhoneNumber))
            throw new ArgumentNullException(nameof(ContactPhoneNumber), "Contact phone number cannot be null or empty.");
    }
}