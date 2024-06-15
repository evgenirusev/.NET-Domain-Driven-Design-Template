using FluentValidation;
using OrderManagement.Application.Orders.Common;

public class OrderCommandValidator : AbstractValidator<OrderModel>
{
    public OrderCommandValidator()
    {
        RuleForEach(c => c.OrderItems)
            .SetValidator(new OrderItemModelValidator());
    }
}

public class OrderItemModelValidator : AbstractValidator<OrderItemModel>
{
    public OrderItemModelValidator()
    {
        RuleFor(oi => oi.ProductId)
            .NotEmpty().WithMessage("Product ID is required.");

        RuleFor(oi => oi.Quantity)
            .GreaterThan(0).WithMessage("Quantity must be greater than zero.");
    }
}