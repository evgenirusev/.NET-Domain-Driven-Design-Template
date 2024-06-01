public class ModelConstants
{
    public class Common
    {
        public const int MinNameLength = 2;
        public const int MaxNameLength = 20;
        public const int MinEmailLength = 3;
        public const int MaxEmailLength = 50;
        public const int MaxUrlLength = 2048;
        public const int Zero = 0;
    }

    public class PhoneNumber
    {
        public const int MinPhoneNumberLength = 5;
        public const int MaxPhoneNumberLength = 20;
        public const string PhoneNumberRegularExpression = @"\+[0-9]*";
    }
}