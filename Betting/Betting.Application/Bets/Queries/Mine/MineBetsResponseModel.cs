namespace BettingSystem.Application.Betting.Bets.Queries.Mine;

using System.Collections.Generic;
using Common;

public class MineBetsResponseModel : BetListingsResponseModel<MineBetResponseModel>
{
    internal MineBetsResponseModel(IEnumerable<MineBetResponseModel> bets)
        : base(bets)
    {
    }
}