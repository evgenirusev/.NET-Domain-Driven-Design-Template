namespace BettingSystem.Domain.Betting.Models.Bets;

using System;
using Exceptions;
using FakeItEasy;
using FluentAssertions;
using Matches;
using Xunit;

public class BetSpecs
{
    [Fact]
    public void ValidBetShouldNotThrowException()
    {
        var match = A.Dummy<Match>();

        Action act = () => new Bet(match, 10, Prediction.Home, true);

        act.Should().NotThrow<InvalidBetException>();
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void InvalidBetAmountShouldThrowException(decimal amount)
    {
        var match = A.Dummy<Match>();

        Action act = () => new Bet(match, amount, Prediction.Away, false);

        act.Should().Throw<InvalidBetException>();
    }

    [Fact]
    public void MakeProfitableShouldSetIsProfitableToTrueIfBetPredictionIsCorrect()
    {
        var match = A.Dummy<Match>();

        var bet = new Bet(match, 10, Prediction.Home, false);

        match.UpdateStatus(Status.Finished);

        bet.MakeProfitable();

        bet.IsProfitable.Should().BeTrue();
    }

    [Fact]
    public void MakeProfitableShouldThrowExceptionIfMatchIsNotFinished()
    {
        var match = A.Dummy<Match>();

        var bet = new Bet(match, 10, Prediction.Home, false);

        Action act = () => bet.MakeProfitable();

        act.Should().Throw<InvalidBetException>();
    }
}