namespace BettingSystem.Domain.Betting.Factories.Gamblers;

using Common;
using Models.Gamblers;

public interface IGamblerFactory : IFactory<Gambler>
{
    IGamblerFactory WithName(string name);

    IGamblerFactory FromUser(string userId);
}