namespace BettingSystem.Domain.Betting.Models.Matches;

using System;
using System.Collections.Generic;
using Common;

internal class MatchData : IInitialData
{
    public Type EntityType => typeof(Match);

    public IEnumerable<object> GetData()
        => new List<Match>
        {
            new(
                DateTime.Today.AddHours(5),
                new Statistics(null, null),
                Status.NotStarted),

            new(
                DateTime.Today.AddDays(2),
                new Statistics(0, 3),
                Status.FirstHalf)
        };
}