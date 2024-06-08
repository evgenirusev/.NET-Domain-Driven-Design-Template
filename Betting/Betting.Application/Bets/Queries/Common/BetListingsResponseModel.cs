namespace BettingSystem.Application.Betting.Bets.Queries.Common;

using System.Collections.Generic;

public abstract class BetListingsResponseModel<TBetResponseModel>
{
    protected internal BetListingsResponseModel(IEnumerable<TBetResponseModel> bets)
        => this.Bets = bets;

    public IEnumerable<TBetResponseModel> Bets { get; }
}