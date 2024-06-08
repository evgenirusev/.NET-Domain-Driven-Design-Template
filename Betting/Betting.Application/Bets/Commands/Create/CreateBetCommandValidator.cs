namespace BettingSystem.Application.Betting.Bets.Commands.Create;

using Domain.Betting.Models.Bets;
using Domain.Common.Models;
using FluentValidation;

using static Domain.Betting.Models.ModelConstants.Bet;

public class CreateBetCommandValidator : AbstractValidator<CreateBetCommand>
{
    public CreateBetCommandValidator()
    {
        this.RuleFor(b => b.Amount)
            .InclusiveBetween(MinAmountValue, MaxAmountValue);

        this.RuleFor(b => b.Prediction)
            .Must(Enumeration.HasValue<Prediction>)
            .WithMessage("'{PropertyName}' is not valid");
    }
}