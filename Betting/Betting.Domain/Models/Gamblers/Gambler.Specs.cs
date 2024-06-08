namespace BettingSystem.Domain.Betting.Models.Gamblers;

using System;
using Bets;
using Exceptions;
using FakeItEasy;
using FluentAssertions;
using Xunit;

public class GamblerSpecs
{
    [Theory]
    [InlineData("Test 1", 5)]
    [InlineData("Test 2", 0)]
    public void ValidGamblerShouldNotThrowException(string name, decimal balance)
    {
        Action act = () => new Gambler(name, Guid.NewGuid().ToString(), balance);

        act.Should().NotThrow<InvalidGamblerException>();
    }

    [Theory]
    [InlineData("", -1)]
    [InlineData("Te", 0)]
    public void InvalidGamblerAmountShouldThrowException(string name, decimal balance)
    {
        Action act = () => new Gambler(name, Guid.NewGuid().ToString(), balance);

        act.Should().Throw<InvalidGamblerException>();
    }

    [Theory]
    [InlineData("Test 1", 5, "Updated 1")]
    [InlineData("Test 2", 0, "Updated 2")]
    public void UpdateNameShouldSetNewNameIfNewNameIsValid(string name, decimal balance, string newName)
    {
        var gambler = new Gambler(name, Guid.NewGuid().ToString(), balance);

        gambler.UpdateName(newName);

        gambler.Name.Should().Be(newName);
    }

    [Theory]
    [InlineData("Test 1", 5, "")]
    [InlineData("Test 2", 0, "  ")]
    [InlineData("Test 3", 0, "Aa")]
    public void UpdateNameShouldThrowExceptionIfNewNameIsInvalid(string name, decimal balance, string newName)
    {
        var gambler = new Gambler(name, Guid.NewGuid().ToString(), balance);

        Action act = () => gambler.UpdateName(newName);

        act.Should().Throw<InvalidGamblerException>();
    }

    [Theory]
    [InlineData("Test 1", 5, 10)]
    [InlineData("Test 2", 0, 20)]
    [InlineData("Test 3", 0, 30)]
    public void DepositShouldIncreaseBalanceIfAmountIsValid(string name, decimal balance, decimal amount)
    {
        var gambler = new Gambler(name, Guid.NewGuid().ToString(), balance);

        gambler.Deposit(amount);

        gambler.Balance.Should().Be(balance + amount);
    }

    [Theory]
    [InlineData("Test 1", 5, 0)]
    [InlineData("Test 2", 0, -1)]
    public void DepositShouldThrowExceptionIfAmountIsInvalid(string name, decimal balance, decimal amount)
    {
        var gambler = new Gambler(name, Guid.NewGuid().ToString(), balance);

        Action act = () => gambler.Deposit(amount);

        act.Should().Throw<InvalidGamblerException>();
    }

    [Theory]
    [InlineData("Test 1", 10, 10)]
    [InlineData("Test 2", 30, 20)]
    [InlineData("Test 3", 40, 30)]
    public void WithdrawShouldDecreaseBalanceIfAmountIsValid(string name, decimal balance, decimal amount)
    {
        var gambler = new Gambler(name, Guid.NewGuid().ToString(), balance);

        gambler.Withdraw(amount);

        gambler.Balance.Should().Be(balance - amount);
    }

    [Theory]
    [InlineData("Test 1", 5, 0)]
    [InlineData("Test 2", 0, 1)]
    [InlineData("Test 3", 0, -1)]
    public void WithdrawShouldThrowExceptionIfAmountIsInvalid(string name, decimal balance, decimal amount)
    {
        var gambler = new Gambler(name, Guid.NewGuid().ToString(), balance);

        Action act = () => gambler.Withdraw(amount);

        act.Should().Throw<InvalidGamblerException>();
    }

    [Theory]
    [InlineData("Test", 5)]
    public void AddBetShouldWork(string name, decimal balance)
    {
        var gambler = new Gambler(name, Guid.NewGuid().ToString(), balance);

        var bet = A.Dummy<Bet>();

        gambler.AddBet(bet);

        gambler.Bets.Count.Should().Be(1);
        gambler.Bets.Should().Contain(bet);
    }
}