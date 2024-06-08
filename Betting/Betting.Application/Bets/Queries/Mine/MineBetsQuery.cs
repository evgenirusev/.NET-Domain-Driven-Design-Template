namespace BettingSystem.Application.Betting.Bets.Queries.Mine;

using System.Threading;
using System.Threading.Tasks;
using Application.Common.Contracts;
using Common;
using Domain.Betting.Repositories;
using MediatR;

public class MineBetsQuery : BetsQuery, IRequest<MineBetsResponseModel>
{
    public class MineBetsQueryHandler : BetsQueryHandler, IRequestHandler<
        MineBetsQuery,
        MineBetsResponseModel>
    {
        private readonly ICurrentUser currentUser;
        private readonly IGamblerDomainRepository gamblerRepository;

        public MineBetsQueryHandler(
            ICurrentUser currentUser,
            IBetQueryRepository betRepository,
            IGamblerDomainRepository gamblerRepository)
            : base(betRepository)
        {
            this.currentUser = currentUser;
            this.gamblerRepository = gamblerRepository;
        }

        public async Task<MineBetsResponseModel> Handle(
            MineBetsQuery request,
            CancellationToken cancellationToken)
        {
            var gamblerId = await this.gamblerRepository.GetGamblerId(
                this.currentUser.UserId,
                cancellationToken);

            var betListings = await base.GetBetsListing<MineBetResponseModel>(
                request,
                gamblerId,
                cancellationToken);

            return new MineBetsResponseModel(betListings);
        }
    }
}