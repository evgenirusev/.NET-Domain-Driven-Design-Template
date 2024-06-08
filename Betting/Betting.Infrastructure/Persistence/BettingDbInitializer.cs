namespace BettingSystem.Infrastructure.Betting.Persistence;

using System.Collections.Generic;
using Common.Persistence;
using Domain.Common;

internal class BettingDbInitializer : DbInitializer
{
    public BettingDbInitializer(
        BettingDbContext db,
        IEnumerable<IInitialData> initialDataProviders)
        : base(db, initialDataProviders)
    {
    }
}