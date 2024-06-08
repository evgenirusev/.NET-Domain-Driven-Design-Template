namespace BettingSystem.Infrastructure.Betting.Repositories;

using System.Threading;
using System.Threading.Tasks;
using Application.Betting.Matches;
using Common.Repositories;
using Domain.Betting.Models.Matches;
using Domain.Betting.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence;

internal class MatchRepository : DataRepository<BettingDbContext, Match>,
    IMatchDomainRepository,
    IMatchQueryRepository
{
    public MatchRepository(BettingDbContext db)
        : base(db)
    {
    }

    public async Task<bool> Delete(
        int id,
        CancellationToken cancellationToken = default)
    {
        var match = await this.Data.Matches.FindAsync(id);

        if (match == null)
        {
            return false;
        }

        this.Data.Matches.Remove(match);

        await this.Data.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<Match?> Find(
        int id,
        CancellationToken cancellationToken = default)
        => await this
            .All()
            .FirstOrDefaultAsync(m => m.Id == id, cancellationToken);
}