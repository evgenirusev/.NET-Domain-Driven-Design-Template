namespace Template.Domain.Exceptions;

public class InvalidCompanyException : BaseException
{
    public InvalidCompanyException()
    {
    }
    
    public InvalidCompanyException(string error) => this.Error = error;
}
