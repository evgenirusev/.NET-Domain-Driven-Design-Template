using FluentValidation;

public class ProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public ProductCommandValidator()
    {
        RuleFor(b => b.Name)
            .NotEmpty().WithMessage("Name is required.")
            .Length(ProductModelConstants.Common.MinNameLength, ProductModelConstants.Common.MaxNameLength)
            .WithMessage($"Name must be between {ProductModelConstants.Common.MinNameLength} and {ProductModelConstants.Common.MaxNameLength} characters.");

        RuleFor(b => b.Description)
            .NotEmpty().WithMessage("Description is required.")
            .Length(ProductModelConstants.Common.MinDescriptionLength, ProductModelConstants.Common.MaxDescriptionLength)
            .WithMessage($"Description must be between {ProductModelConstants.Common.MinDescriptionLength} and {ProductModelConstants.Common.MaxDescriptionLength} characters.");

        RuleFor(b => b.Price.Amount)
            .NotEmpty().WithMessage("Price amount is required.")
            .GreaterThan(ProductModelConstants.Common.Zero).WithMessage("Price amount must be greater than zero.")
            .ScalePrecision(2, ProductModelConstants.Price.MaxAmountDigits)
            .WithMessage($"Price amount must have at most {ProductModelConstants.Price.MaxAmountDigits} digits.");

        RuleFor(b => b.Price.Currency)
            .NotEmpty().WithMessage("Price currency is required.")
            .MaximumLength(ProductModelConstants.Price.MaxCurrencyLength)
            .WithMessage($"Price currency must have at most {ProductModelConstants.Price.MaxCurrencyLength} characters.");

        RuleFor(b => b.Weight.Value)
            .NotEmpty().WithMessage("Weight value is required.")
            .GreaterThan(ProductModelConstants.Common.Zero).WithMessage("Weight value must be greater than zero.")
            .ScalePrecision(2, ProductModelConstants.Weight.MaxValueDigits)
            .WithMessage($"Weight value must have at most {ProductModelConstants.Weight.MaxValueDigits} digits.");

        RuleFor(b => b.Weight.Unit)
            .NotEmpty().WithMessage("Weight unit is required.")
            .MaximumLength(ProductModelConstants.Weight.MaxUnitLength)
            .WithMessage($"Weight unit must have at most {ProductModelConstants.Weight.MaxUnitLength} characters.");
    }
}