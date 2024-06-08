namespace BettingSystem.Domain.Betting.Factories.Bets;

using Exceptions;
using Models.Bets;
using Models.Matches;

internal class BetFactory : IBetFactory
{
    private Match betMatch = default!;
    private decimal betAmount = default!;
    private Prediction betPrediction = default!;

    private bool isMatchSet = false;
    private bool isAmountSet = false;
    private bool isPredictionSet = false;

    public IBetFactory WithMatch(Match match)
    {
        this.betMatch = match;
        this.isMatchSet = true;

        return this;
    }

    public IBetFactory WithAmount(decimal amount)
    {
        this.betAmount = amount;
        this.isAmountSet = true;

        return this;
    }

    public IBetFactory WithPrediction(Prediction prediction)
    {
        this.betPrediction = prediction;
        this.isPredictionSet = true;

        return this;
    }

    public Bet Build()
    {
        if (!this.isMatchSet || !this.isAmountSet || !this.isPredictionSet)
        {
            throw new InvalidBetException("Match, amount and prediction must have a value.");
        }

        return new Bet(
            this.betMatch,
            this.betAmount,
            this.betPrediction,
            isProfitable: false);
    }
}