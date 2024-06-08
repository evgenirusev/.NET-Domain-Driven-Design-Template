namespace BettingSystem.Domain.Betting.Repositories;

using System.Threading;
using System.Threading.Tasks;
using Common;
using Models.Gamblers;

public interface IGamblerDomainRepository : IDomainRepository<Gambler>
{
    Task<Gambler> FindByUser(
        string userId,
        CancellationToken cancellationToken = default);

    Task<int> GetGamblerId(
        string userId,
        CancellationToken cancellationToken = default);

    Task<bool> HasBet(
        int gamblerId,
        int betId,
        CancellationToken cancellationToken = default);
}