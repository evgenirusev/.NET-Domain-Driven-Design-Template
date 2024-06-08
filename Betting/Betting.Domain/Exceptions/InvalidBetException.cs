namespace BettingSystem.Domain.Betting.Exceptions;

using Common;

public class InvalidBetException : BaseDomainException
{
    public InvalidBetException()
    {
    }

    public InvalidBetException(string error) => this.Error = error;
}