using FluentValidation;

public class ProductCommandValidator : AbstractValidator<ProductCommand>
{
    public ProductCommandValidator()
    {
        RuleFor(b => b.Name)
            .NotEmpty().WithMessage("Name is required.")
            .Length(ProductModelConstants.Product.MinNameLength, ProductModelConstants.Product.MaxNameLength)
            .WithMessage($"Name must be between {ProductModelConstants.Product.MinNameLength} and {ProductModelConstants.Product.MaxNameLength} characters.");

        RuleFor(b => b.Description)
            .NotEmpty().WithMessage("Description is required.")
            .Length(ProductModelConstants.Product.MinDescriptionLength, ProductModelConstants.Product.MaxDescriptionLength)
            .WithMessage($"Description must be between {ProductModelConstants.Product.MinDescriptionLength} and {ProductModelConstants.Product.MaxDescriptionLength} characters.");

        RuleFor(b => b.Price.Amount)
            .NotEmpty().WithMessage("Price amount is required.")
            .GreaterThan(CommonModelConstants.Common.Zero).WithMessage("Price amount must be greater than zero.")
            .ScalePrecision(2, ProductModelConstants.Price.MaxAmountDigits)
            .WithMessage($"Price amount must have at most {ProductModelConstants.Price.MaxAmountDigits} digits.");

        RuleFor(b => b.Price.Currency)
            .NotEmpty().WithMessage("Price currency is required.")
            .MaximumLength(ProductModelConstants.Price.MaxCurrencyLength)
            .WithMessage($"Price currency must have at most {ProductModelConstants.Price.MaxCurrencyLength} characters.");

        RuleFor(b => b.Weight.Value)
            .NotEmpty().WithMessage("Weight value is required.")
            .GreaterThan(CommonModelConstants.Common.Zero).WithMessage("Weight value must be greater than zero.")
            .ScalePrecision(2, ProductModelConstants.Weight.MaxValueDigits)
            .WithMessage($"Weight value must have at most {ProductModelConstants.Weight.MaxValueDigits} digits.");

        RuleFor(b => b.Weight.Unit)
            .NotEmpty().WithMessage("Weight unit is required.")
            .MaximumLength(ProductModelConstants.Weight.MaxUnitLength)
            .WithMessage($"Weight unit must have at most {ProductModelConstants.Weight.MaxUnitLength} characters.");
    }
}