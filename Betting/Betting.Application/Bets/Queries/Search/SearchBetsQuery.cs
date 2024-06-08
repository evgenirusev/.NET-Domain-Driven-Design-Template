namespace BettingSystem.Application.Betting.Bets.Queries.Search;

using System.Threading;
using System.Threading.Tasks;
using Common;
using MediatR;

public class SearchBetsQuery : BetsQuery, IRequest<SearchBetsResponseModel>
{
    public class SearchBetsQueryHandler : BetsQueryHandler, IRequestHandler<
        SearchBetsQuery,
        SearchBetsResponseModel>
    {
        public SearchBetsQueryHandler(IBetQueryRepository betRepository)
            : base(betRepository)
        {
        }

        public async Task<SearchBetsResponseModel> Handle(
            SearchBetsQuery request,
            CancellationToken cancellationToken)
        {
            var betListings = await base.GetBetsListing<BetResponseModel>(
                request,
                cancellationToken: cancellationToken);

            return new SearchBetsResponseModel(betListings);
        }
    }
}