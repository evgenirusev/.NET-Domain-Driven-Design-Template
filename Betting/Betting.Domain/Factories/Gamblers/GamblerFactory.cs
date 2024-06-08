namespace BettingSystem.Domain.Betting.Factories.Gamblers;

using Exceptions;
using Models.Gamblers;

internal class GamblerFactory : IGamblerFactory
{
    private string gamblerName = default!;
    private string gamblerUserId = default!;

    private bool isNameSet = false;
    private bool isUserIdSet = false;

    public IGamblerFactory WithName(string name)
    {
        this.gamblerName = name;
        this.isNameSet = true;

        return this;
    }

    public IGamblerFactory FromUser(string userId)
    {
        this.gamblerUserId = userId;
        this.isUserIdSet = true;

        return this;
    }

    public Gambler Build()
    {
        if (!this.isNameSet || !this.isUserIdSet)
        {
            throw new InvalidGamblerException("Name and User Id must have a value");
        }

        return new Gambler(
            this.gamblerName,
            this.gamblerUserId,
            balance: decimal.Zero);
    }
}