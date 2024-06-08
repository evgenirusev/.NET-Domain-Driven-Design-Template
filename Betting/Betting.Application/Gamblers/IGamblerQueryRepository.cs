namespace BettingSystem.Application.Betting.Gamblers;

using System.Threading;
using System.Threading.Tasks;
using Common.Contracts;
using Domain.Betting.Models.Gamblers;
using Queries.Details;

public interface IGamblerQueryRepository : IQueryRepository<Gambler>
{
    Task<GamblerDetailsResponseModel?> GetDetails(
        int id,
        CancellationToken cancellationToken = default);
}