namespace BettingSystem.Domain.Betting.Models.Matches;

using System;
using Exceptions;
using FakeItEasy;
using FluentAssertions;
using Xunit;

public class MatchSpecs
{
    [Fact]
    public void ValidMatchShouldNotThrowException()
    {
        Action act = () => A.Dummy<Match>();

        act.Should().NotThrow<InvalidMatchException>();
    }

    [Fact]
    public void InvalidMatchDateShouldThrowException()
    {
        Action act = () => new Match(
            DateTime.Today.AddDays(-1), 
            A.Dummy<Statistics>(), 
            Status.NotStarted);

        act.Should().Throw<InvalidMatchException>();
    }

    [Fact]
    public void UpdateStartDateShouldSetNewStartDateIfDateIsValid()
    {
        var match = A.Dummy<Match>();

        var nextWeek = DateTime.Today.AddDays(7);

        match.UpdateStartDate(nextWeek);

        match.StartDate.Should().Be(nextWeek);
    }

    [Fact]
    public void UpdateStartDateShouldThrowExceptionIfDateIsInvalid()
    {
        var match = A.Dummy<Match>();

        var previousWeek = DateTime.Today.AddDays(-7);

        Action act = () => match.UpdateStartDate(previousWeek);

        act.Should().Throw<InvalidMatchException>();
    }

    [Fact]
    public void UpdateStatusShouldSetNewStatus()
    {
        var match = A.Dummy<Match>();

        match.UpdateStatus(Status.Cancelled);

        match.Status.Should().Be(Status.Cancelled);
    }
}