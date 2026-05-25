using FluentValidation;

public class ChangePasswordCommandValidator : AbstractValidator<ChangePasswordCommand>
{
    public ChangePasswordCommandValidator()
    {
        RuleFor(c => c.CurrentPassword)
            .NotEmpty().WithMessage("Current password is required.");

        RuleFor(c => c.NewPassword)
            .NotEmpty().WithMessage("New password is required.")
            .MinimumLength(CommonModelConstants.Identity.MinPasswordLength)
                .WithMessage($"New password must be at least {CommonModelConstants.Identity.MinPasswordLength} characters.")
            .MaximumLength(CommonModelConstants.Identity.MaxPasswordLength)
                .WithMessage($"New password must be at most {CommonModelConstants.Identity.MaxPasswordLength} characters.");
    }
}
