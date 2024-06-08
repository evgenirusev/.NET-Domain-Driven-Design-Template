namespace BettingSystem.Domain.Betting.Models.Matches;

using System;
using Common;
using Common.Models;
using Exceptions;

public class Match : Entity<int>, IAggregateRoot
{
    internal Match(
        DateTime startDate,
        Statistics statistics,
        Status status)
    {
        this.Validate(startDate);

        this.StartDate = startDate;
        this.Statistics = statistics;
        this.Status = status;
    }

    private Match(DateTime startDate)
    {
        this.StartDate = startDate;

        this.Statistics = default!;
        this.Status = default!;
    }

    public DateTime StartDate { get; private set; }

    public Statistics Statistics { get; private set; }

    public Status Status { get; private set; }

    public Match UpdateStartDate(DateTime startDate)
    {
        this.Validate(startDate);

        this.StartDate = startDate;

        return this;
    }

    public Match UpdateStatus(Status status)
    {
        this.Status = status;

        return this;
    }

    private void Validate(DateTime startDate)
    {
        if (startDate < DateTime.Today)
        {
            throw new InvalidMatchException();
        }
    }
}