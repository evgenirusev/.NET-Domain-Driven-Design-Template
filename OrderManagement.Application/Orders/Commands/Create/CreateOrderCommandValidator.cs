using FluentValidation;

public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
        => Include(new CreateOrderCommandValidator());
}