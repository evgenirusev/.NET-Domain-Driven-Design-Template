namespace BettingSystem.Application.Betting.Bets.Queries.Common;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Betting.Models.Bets;
using Domain.Betting.Models.Gamblers;
using Domain.Betting.Specifications.Bets;
using Domain.Betting.Specifications.Gamblers;
using Domain.Common;

public abstract class BetsQuery
{
    public bool? OnlyProfitable { get; set; }

    public abstract class BetsQueryHandler
    {
        private readonly IBetQueryRepository betRepository;

        protected BetsQueryHandler(IBetQueryRepository betRepository)
            => this.betRepository = betRepository;

        protected async Task<IEnumerable<TResponseModel>> GetBetsListing<TResponseModel>(
            BetsQuery request,
            int? gamblerId = default,
            CancellationToken cancellationToken = default)
        {
            var betSpecification = this.GetBetSpecification(request);

            var gamblerSpecification = this.GetGamblerSpecification(gamblerId);

            return await this.betRepository.GetBetsListing<TResponseModel>(
                betSpecification,
                gamblerSpecification,
                cancellationToken);
        }

        private Specification<Bet> GetBetSpecification(BetsQuery request)
            => new BetOnlyProfitableSpecification(request.OnlyProfitable);

        private Specification<Gambler> GetGamblerSpecification(int? gamblerId)
            => new GamblerByIdSpecification(gamblerId);
    }
}