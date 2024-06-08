namespace BettingSystem.Domain.Betting.Factories.Bets;

using Common;
using Models.Bets;
using Models.Matches;

public interface IBetFactory : IFactory<Bet>
{
    IBetFactory WithMatch(Match match);

    IBetFactory WithAmount(decimal amount);

    IBetFactory WithPrediction(Prediction prediction);
}