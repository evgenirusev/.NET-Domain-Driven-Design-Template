using Template.Domain.Company.Models;
using Template.Domain.Exceptions;

namespace CarRentalSystem.Domain.Factories.CarAds
{
    internal class CompanyFactory : ICompanyFactory
    {
        private string companyName = default!;
        private Address address = default!;
        private string companyHouseNumber = default!;
        
        private bool companyNameSet = false;
        private bool companyHouseNumberSet = false;
        private bool addressSet = false;        

        public ICompanyFactory WithName(string name)
        {
            companyName = name;
            companyNameSet = true;
            return this;
        }

        public ICompanyFactory WithCompanyHouseNumber(string companyHouseNumber)
        {
            this.companyHouseNumber = companyHouseNumber;
            companyHouseNumberSet = true;
            return this;
        }

        public ICompanyFactory WithAddress(Address address)
        {
            this.address = address;
            addressSet = true;
            return this;
        }
        
        public Company Build()
        {
            if (!this.companyNameSet || !this.addressSet || !this.companyHouseNumberSet)
                throw new InvalidCompanyException("Company name, address and ch number must have a value.");

            return new Company(companyName, address, companyHouseNumber);
        }
    }
}
