namespace BettingSystem.Domain.Betting.Models.Gamblers;

using System.Collections.Generic;
using System.Linq;
using Bets;
using Common;
using Common.Models;
using Exceptions;

using static ModelConstants.Gambler;
using static Common.Models.ModelConstants.Common;

public class Gambler : Entity<int>, IAggregateRoot
{
    private readonly HashSet<Bet> bets;

    internal Gambler(
        string name,
        string userId,
        decimal balance)
    {
        this.Validate(name, balance);

        this.Name = name;
        this.UserId = userId;
        this.Balance = balance;

        this.bets = new HashSet<Bet>();
    }

    public string Name { get; private set; }

    public string UserId { get; private set; }

    public decimal Balance { get; private set; }

    public IReadOnlyCollection<Bet> Bets => this.bets.ToList().AsReadOnly();

    public Gambler UpdateName(string name)
    {
        this.ValidateName(name);

        this.Name = name;

        return this;
    }

    public Gambler Deposit(decimal amount)
    {
        this.ValidateAmount(amount);

        this.Balance += amount;

        return this;
    }

    public Gambler Withdraw(decimal amount)
    {
        this.ValidateAmount(amount);
        this.ValidateBalance(this.Balance - amount);

        this.Balance -= amount;

        return this;
    }

    public Gambler AddBet(Bet bet)
    {
        this.bets.Add(bet);

        return this;
    }

    private void Validate(string name, decimal balance)
    {
        this.ValidateName(name);
        this.ValidateBalance(balance);
    }

    private void ValidateName(string name)
        => Guard.ForStringLength<InvalidGamblerException>(
            name,
            MinNameLength,
            MaxNameLength,
            nameof(this.Name));

    private void ValidateBalance(decimal balance)
        => Guard.AgainstOutOfRange<InvalidGamblerException>(
            balance,
            MinBalanceValue,
            MaxBalanceValue,
            nameof(this.Balance));

    private void ValidateAmount(decimal amount)
        => Guard.AgainstOutOfRange<InvalidGamblerException>(
            amount,
            MinAmountValue,
            MaxAmountValue,
            nameof(amount));
}