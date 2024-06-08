namespace BettingSystem.Application.Betting.Bets.Queries.Search;

using System.Collections.Generic;
using Common;

public class SearchBetsResponseModel : BetListingsResponseModel<BetResponseModel>
{
    internal SearchBetsResponseModel(IEnumerable<BetResponseModel> bets)
        : base(bets)
    {
    }
}