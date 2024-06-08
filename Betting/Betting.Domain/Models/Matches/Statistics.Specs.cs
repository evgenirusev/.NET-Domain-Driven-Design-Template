namespace BettingSystem.Domain.Betting.Models.Matches;

using System;
using Exceptions;
using FluentAssertions;
using Xunit;

public class StatisticsSpecs
{
    [Theory]
    [InlineData(3, 0)]
    [InlineData(0, 3)]
    [InlineData(null, null)]
    public void ValidStatisticShouldNotThrowException(int? homeScore, int? awayScore)
    {
        Action act = () => new Statistics(homeScore, awayScore);

        act.Should().NotThrow<InvalidMatchException>();
    }

    [Theory]
    [InlineData(-1, 0)]
    [InlineData(0, -1)]
    [InlineData(-1, -1)]
    public void InvalidStatisticShouldThrowException(int? homeScore, int? awayScore)
    {
        Action act = () => new Statistics(homeScore, awayScore);

        act.Should().Throw<InvalidMatchException>();
    }

    [Theory]
    [InlineData(3, 0, 1)]
    [InlineData(null, null, 2)]
    public void UpdateHomeScoreShouldSetHomeScoreIfScoreIsValid(int? homeScore, int? awayScore, int? newHomeScore)
    {
        var statistics = new Statistics(homeScore, awayScore);

        statistics.UpdateHomeScore(newHomeScore);

        statistics.HomeScore.Should().Be(newHomeScore);
    }

    [Theory]
    [InlineData(3, 0, -1)]
    [InlineData(null, null, -1)]
    public void UpdateHomeScoreThrowExceptionIfScoreIsInvalid(int? homeScore, int? awayScore, int? newHomeScore)
    {
        var statistics = new Statistics(homeScore, awayScore);

        Action act = () => statistics.UpdateHomeScore(newHomeScore);

        act.Should().Throw<InvalidMatchException>();
    }

    [Theory]
    [InlineData(3, 0, 1)]
    [InlineData(null, null, 2)]
    public void UpdateAwayScoreShouldSetAwayScoreIfScoreIsValid(int? homeScore, int? awayScore, int? newAwayScore)
    {
        var statistics = new Statistics(homeScore, awayScore);

        statistics.UpdateAwayScore(newAwayScore);

        statistics.AwayScore.Should().Be(newAwayScore);
    }

    [Theory]
    [InlineData(3, 0, -1)]
    [InlineData(null, null, -1)]
    public void UpdateAwayScoreThrowExceptionIfScoreIsInvalid(int? homeScore, int? awayScore, int? newAwayScore)
    {
        var statistics = new Statistics(homeScore, awayScore);

        Action act = () => statistics.UpdateAwayScore(newAwayScore);

        act.Should().Throw<InvalidMatchException>();
    }

    [Theory]
    [InlineData(0, 0, 1, 0)]
    [InlineData(1, 1, 3, 1)]
    public void UpdateHalfTimeScoreShouldSetHalftimeScoreIfScoresAreValid(
        int? homeScore,
        int? awayScore,
        int? newHalfTimeHomeScore,
        int? newHalfTimeAwayScore)
    {
        var statistics = new Statistics(homeScore, awayScore);

        statistics.UpdateHalfTimeScore(newHalfTimeHomeScore, newHalfTimeAwayScore);

        statistics.HalfTimeHomeScore.Should().Be(newHalfTimeHomeScore);
        statistics.HalfTimeAwayScore.Should().Be(newHalfTimeAwayScore);
    }

    [Theory]
    [InlineData(0, 0, -1, 0)]
    [InlineData(0, 0, 0, -1)]
    public void UpdateHalfTimeScoreThrowExceptionIfScoresAreInvalid(
        int? homeScore,
        int? awayScore,
        int? newHalfTimeHomeScore,
        int? newHalfTimeAwayScore)
    {
        var statistics = new Statistics(homeScore, awayScore);

        Action act = () => statistics.UpdateHalfTimeScore(newHalfTimeHomeScore, newHalfTimeAwayScore);

        act.Should().Throw<InvalidMatchException>();
    }
}