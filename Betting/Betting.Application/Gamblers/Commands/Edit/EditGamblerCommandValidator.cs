namespace BettingSystem.Application.Betting.Gamblers.Commands.Edit;

using Common;
using FluentValidation;

public class EditGamblerCommandValidator : AbstractValidator<EditGamblerCommand>
{
    public EditGamblerCommandValidator()
        => this.Include(new GamblerCommandValidator<EditGamblerCommand>());
}