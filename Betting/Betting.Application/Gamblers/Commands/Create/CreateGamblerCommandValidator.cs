namespace BettingSystem.Application.Betting.Gamblers.Commands.Create;

using Common;
using FluentValidation;

public class CreateGamblerCommandValidator : AbstractValidator<CreateGamblerCommand>
{
    public CreateGamblerCommandValidator()
        => this.Include(new GamblerCommandValidator<CreateGamblerCommand>());
}