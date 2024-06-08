namespace BettingSystem.Application.Betting.Bets;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Common.Contracts;
using Domain.Betting.Models.Bets;
using Domain.Betting.Models.Gamblers;
using Domain.Common;
using Queries.Details;

public interface IBetQueryRepository : IQueryRepository<Bet>
{
    Task<BetDetailsResponseModel?> GetDetails(
        int id,
        CancellationToken cancellationToken = default);

    Task<IEnumerable<TResponseModel>> GetBetsListing<TResponseModel>(
        Specification<Bet> betSpecification,
        Specification<Gambler> gamblerSpecification,
        CancellationToken cancellationToken = default);
}