namespace Template.Domain.Company.Models;

public class CompanyStructure : Enumeration
{
    public static CompanyStructure LTD = new(1, nameof(LTD));  // Private Company Limited by Shares
    public static CompanyStructure LLP = new(2, nameof(LLP));  // Limited Liability Partnership
    public static CompanyStructure LP = new(3, nameof(LP)); // Limited Partnerhip
    public static CompanyStructure PLC = new(4, nameof(PLC)); // Public Limited Company
    public static CompanyStructure PUC = new(5, nameof(PUC)); // Private Unlimited Company

    private CompanyStructure(int value)
        : this(value, FromValue<CompanyStructure>(value).Name)
    {
    }

    private CompanyStructure(int value, string name) 
        : base(value, name)
    {
    }
}