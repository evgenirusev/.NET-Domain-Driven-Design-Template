namespace BettingSystem.Application.Betting.Gamblers.Commands.Deposit;

using Common;
using FluentValidation;

public class GamblerDepositMoneyCommandValidator : AbstractValidator<GamblerDepositMoneyCommand>
{
    public GamblerDepositMoneyCommandValidator()
        => this.Include(new GamblerMoneyCommandValidator<GamblerDepositMoneyCommand>());
}