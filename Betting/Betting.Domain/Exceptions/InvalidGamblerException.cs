namespace BettingSystem.Domain.Betting.Exceptions;

using Common;

public class InvalidGamblerException : BaseDomainException
{
    public InvalidGamblerException()
    {
    }

    public InvalidGamblerException(string error) => this.Error = error;
}