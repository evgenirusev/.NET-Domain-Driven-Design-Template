namespace BettingSystem.Application.Betting.Gamblers.Commands.Withdraw;

using Common;
using FluentValidation;

public class GamblerWithdrawMoneyCommandValidator : AbstractValidator<GamblerWithdrawMoneyCommand>
{
    public GamblerWithdrawMoneyCommandValidator()
        => this.Include(new GamblerMoneyCommandValidator<GamblerWithdrawMoneyCommand>());
}