public static class Guard
{
    public static void AgainstEmptyString(string value, string name = "Value")
    {
        if (!string.IsNullOrEmpty(value))
            return;

        ThrowArgumentException($"{name} cannot be null or empty.");
    }

    public static void ForStringLength(string value, int minLength, int maxLength, string name = "Value")
    {
        AgainstEmptyString(value, name);

        if (value.Length >= minLength && value.Length <= maxLength)
            return;

        ThrowArgumentException($"{name} must have between {minLength} and {maxLength} symbols.");
    }

    public static void AgainstOutOfRange(int number, int min, int max, string name = "Value")
    {
        if (number >= min && number <= max)
            return;

        ThrowArgumentException($"{name} must be between {min} and {max}.");
    }

    public static void AgainstOutOfRange(decimal number, decimal min, decimal max, string name = "Value")
    {
        if (number >= min && number <= max)
            return;

        ThrowArgumentException($"{name} must be between {min} and {max}.");
    }

    public static void Against(object actualValue, object unexpectedValue, string name = "Value")
    {
        if (!actualValue.Equals(unexpectedValue))
            return;

        ThrowArgumentException($"{name} must not be {unexpectedValue}.");
    }

    private static void ThrowArgumentException(string message)
    {
        throw new ArgumentException(message);
    }
}