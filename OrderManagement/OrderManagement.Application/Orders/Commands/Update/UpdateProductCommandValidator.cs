using FluentValidation;

public class UpdateProductCommandValidator : AbstractValidator<OrderCommand>
{
    public UpdateProductCommandValidator() 
        => Include(new OrderCommandValidator());
}