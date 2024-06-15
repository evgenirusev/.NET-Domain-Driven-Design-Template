public class SupplierModelConstants
{
    public class Common
    {
        public const int MinNameLength = 2;
        public const int MaxNameLength = 100;
        public const int MinAddressLength = 10;
        public const int MaxAddressLength = 200;
        public const int MinEmailLength = 5;
        public const int MaxEmailLength = 100;
        public const int MinPhoneNumberLength = 5;
        public const int MaxPhoneNumberLength = 20;
    }
    
    public static class Address
    {
        public const int MinAddressLineLength = 2;
        public const int MaxAddressLineLength = 500;
        public const int MinPostalCodeLength = 2;
        public const int MaxPostalCodeLength = 10;
    }
}