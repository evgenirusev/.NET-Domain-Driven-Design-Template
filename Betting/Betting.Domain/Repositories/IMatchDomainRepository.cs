namespace BettingSystem.Domain.Betting.Repositories;

using System.Threading;
using System.Threading.Tasks;
using Common;
using Models.Matches;

public interface IMatchDomainRepository : IDomainRepository<Match>
{
    Task<bool> Delete(
        int id,
        CancellationToken cancellationToken = default);

    Task<Match?> Find(
        int id,
        CancellationToken cancellationToken = default);
}