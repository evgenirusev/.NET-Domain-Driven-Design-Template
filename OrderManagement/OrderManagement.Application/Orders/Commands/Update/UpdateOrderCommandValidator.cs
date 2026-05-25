using FluentValidation;

public class UpdateOrderCommandValidator : AbstractValidator<OrderCommand>
{
    public UpdateOrderCommandValidator() 
        => Include(new OrderCommandValidator());
}