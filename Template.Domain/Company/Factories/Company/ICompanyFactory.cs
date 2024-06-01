using Template.Domain.Company.Models;

public interface ICompanyFactory : IFactory<Company>
{
    ICompanyFactory WithName(string name);
    ICompanyFactory WithCompanyHouseNumber(string companyHouseNumber);
    ICompanyFactory WithAddress(Address address);
}