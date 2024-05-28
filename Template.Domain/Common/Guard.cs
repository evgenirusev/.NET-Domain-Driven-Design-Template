using Template.Domain.Exceptions;

public static class Guard
{
    public static void AgainstEmptyString<TException>(string value, string name = "Value")
        where TException : BaseException, new()
    {
        if (!string.IsNullOrEmpty(value))
        {
            return;
        }

        ThrowException<TException>($"{name} cannot be null ot empty.");
    }

    public static void ForStringLength<TException>(string value, int minLength, int maxLength, string name = "Value")
        where TException : BaseException, new()
    {
        AgainstEmptyString<TException>(value, name);

        if (minLength <= value.Length && value.Length <= maxLength)
        {
            return;
        }

        ThrowException<TException>($"{name} must have between {minLength} and {maxLength} symbols.");
    }

    public static void AgainstOutOfRange<TException>(int number, int min, int max, string name = "Value")
        where TException : BaseException, new()
    {
        if (min <= number && number <= max)
        {
            return;
        }

        ThrowException<TException>($"{name} must be between {min} and {max}.");
    }

    public static void AgainstOutOfRange<TException>(decimal number, decimal min, decimal max, string name = "Value")
        where TException : BaseException, new()
    {
        if (min <= number && number <= max)
        {
            return;
        }

        ThrowException<TException>($"{name} must be between {min} and {max}.");
    }

    public static void ForValidUrl<TException>(string url, string name = "Value")
        where TException : BaseException, new()
    {
        if (url.Length <= ModelConstants.Common.MaxUrlLength &&
            Uri.IsWellFormedUriString(url, UriKind.Absolute))
        {
            return;
        }

        ThrowException<TException>($"{name} must be a valid URL.");
    }


    public static void Against<TException>(object actualValue, object unexpectedValue, string name = "Value")
        where TException : BaseException, new()
    {
        if (!actualValue.Equals(unexpectedValue))
        {
            return;
        }

        ThrowException<TException>($"{name} must not be {unexpectedValue}.");
    }

    private static void ThrowException<TException>(string message)
        where TException : BaseException, new()
    {
        var exception = new TException
        {
            Error = message
        };

        throw exception;
    }
}