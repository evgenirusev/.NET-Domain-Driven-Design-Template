namespace BettingSystem.Application.Betting.Gamblers.Commands.Common;

using Application.Common;
using FluentValidation;

using static Domain.Betting.Models.ModelConstants.Gambler;

public class GamblerMoneyCommandValidator<TCommand> : AbstractValidator<GamblerMoneyCommand<TCommand>>
    where TCommand : EntityCommand<int>
{
    public GamblerMoneyCommandValidator()
        => this.RuleFor(g => g.Amount)
            .InclusiveBetween(MinDepositWithdrawValue, MaxDepositWithdrawValue);
}