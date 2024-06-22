using FluentValidation;
    
public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidator()
    {
        RuleFor(u => u.Email)
            .MinimumLength(CommonModelConstants.Identity.MinEmailLength)
            .MaximumLength(CommonModelConstants.Identity.MaxEmailLength)
            .EmailAddress()
            .NotEmpty();

        RuleFor(u => u.Password)
            .MinimumLength(CommonModelConstants.Identity.MinPasswordLength)
            .MaximumLength(CommonModelConstants.Identity.MaxPasswordLength)
            .NotEmpty();

        RuleFor(u => u.ConfirmPassword)
            .Equal(u => u.Password)
            .WithMessage("The password and confirmation password do not match.")
            .NotEmpty();
    }
}