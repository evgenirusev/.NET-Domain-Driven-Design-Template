namespace BettingSystem.Domain.Betting.Exceptions;

using Common;

public class InvalidMatchException : BaseDomainException
{
    public InvalidMatchException()
    {
    }

    public InvalidMatchException(string error) => this.Error = error;
}