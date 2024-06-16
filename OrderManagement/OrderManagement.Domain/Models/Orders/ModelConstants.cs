public class OrderModelConstants
{
    public class Order
    {
        public const int MinOrderItems = 1;
        public const int MaxOrderItems = 100;
    }

    public class OrderItem
    {
        public const int MinQuantity = 1;
        public const int MaxQuantity = 1000;
    }

    public class Price
    {
        public const int MaxAmountDigits = 10; // Assuming a maximum of 10 digits for the price amount
        public const int MaxCurrencyLength = 3; // Assuming a maximum currency code length of 3 characters
    }
}