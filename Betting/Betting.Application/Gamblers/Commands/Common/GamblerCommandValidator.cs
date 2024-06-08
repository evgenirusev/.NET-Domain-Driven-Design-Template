namespace BettingSystem.Application.Betting.Gamblers.Commands.Common;

using Application.Common;
using FluentValidation;

using static Domain.Common.Models.ModelConstants.Common;

public class GamblerCommandValidator<TCommand> : AbstractValidator<GamblerCommand<TCommand>>
    where TCommand : EntityCommand<int>
{
    public GamblerCommandValidator()
        => this.RuleFor(u => u.Name)
            .MinimumLength(MinNameLength)
            .MaximumLength(MaxNameLength)
            .NotEmpty();
}