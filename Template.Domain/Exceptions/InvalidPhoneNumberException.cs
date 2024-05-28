namespace Template.Domain.Exceptions;

public class InvalidPhoneNumberException : BaseException
{
    public InvalidPhoneNumberException()
    {
    }
    
    public InvalidPhoneNumberException(string error) => this.Error = error;
}
