namespace BettingSystem.Domain.Betting.Factories.Matches;

using System;
using Exceptions;
using Models.Matches;

internal class MatchFactory : IMatchFactory
{
    private readonly Status defaultMatchStatus = Status.NotStarted;
    private readonly Statistics defaultMatchStatistics = new(homeScore: null, awayScore: null);

    private DateTime matchStartDate = default!;

    private bool isStartDateSet = false;

    public IMatchFactory WithStartDate(DateTime startDate)
    {
        this.matchStartDate = startDate;
        this.isStartDateSet = true;

        return this;
    }

    public Match Build()
    {
        if (!this.isStartDateSet)
        {
            throw new InvalidMatchException("Start Date must have a value");
        }

        return new Match(
            this.matchStartDate,
            this.defaultMatchStatistics,
            this.defaultMatchStatus);
    }

    public Match Build(DateTime startDate)
        => this.WithStartDate(startDate).Build();
}