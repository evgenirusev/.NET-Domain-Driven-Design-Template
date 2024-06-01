using Template.Domain.Common;
using Template.Domain.Exceptions;

namespace Template.Domain.Company.Models;

public class Company : Entity<int>, IAggregateRoot
{
    internal Company(
        string companyName,
        Address address,
        string companiesHouseNumber)
    {
        Validate(companyName, companiesHouseNumber);
        
        this.CompanyName = companyName;
        this.Address = address;
        this.CompaniesHouseNumber = companiesHouseNumber;
    }
    
    public string CompanyName { get; private set; }
    public Address Address { get; private set; }
    public string CompaniesHouseNumber { get; private set; }
    

    private void Validate(string companyName, string companyHouseNumber)
    {
        ValidateCompanyName(companyName);
        ValidateCompanyHouseNumber(companyHouseNumber);
    }
    
    private void ValidateCompanyName(string name)
        => Guard.ForStringLength<InvalidCompanyException>(
            name,
            2,
            50,
            nameof(CompanyName));
    
    private void ValidateCompanyHouseNumber(string companyHouseNumber)
        => Guard.ForStringLength<InvalidCompanyException>(
            companyHouseNumber,
            5,
            10,
            nameof(CompaniesHouseNumber));
}