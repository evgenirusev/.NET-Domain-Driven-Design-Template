using FluentValidation;

public class CreateProductCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateProductCommandValidator()
        => Include(new ProductCommandValidator());
}