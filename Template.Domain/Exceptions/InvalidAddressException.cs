using Template.Common.Exceptions;

namespace Template.Domain.Exceptions;

public class InvalidAddressException : BaseException
{
    public InvalidAddressException()
    {
    }
    
    public InvalidAddressException(string error) => this.Error = error;
}
