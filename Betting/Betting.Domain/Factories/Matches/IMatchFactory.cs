namespace BettingSystem.Domain.Betting.Factories.Matches;

using System;
using Common;
using Models.Matches;

public interface IMatchFactory : IFactory<Match>
{
    IMatchFactory WithStartDate(DateTime startDate);

    Match Build(DateTime startDate);
}