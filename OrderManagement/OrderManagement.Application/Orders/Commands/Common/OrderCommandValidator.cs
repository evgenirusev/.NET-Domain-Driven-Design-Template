using FluentValidation;

public class OrderCommandValidator : AbstractValidator<OrderCommand>
{
    public OrderCommandValidator()
    {
        RuleFor(o => o.CustomerId)
            .GreaterThan(0).WithMessage("Customer ID must be greater than zero.");

        RuleFor(o => o.OrderDate)
            .LessThanOrEqualTo(DateTime.Now).WithMessage("Order date cannot be in the future.");

        RuleFor(o => o.OrderItems)
            .NotEmpty().WithMessage("Order must contain at least one order item.")
            .Must(orderItems => orderItems.Count >= OrderModelConstants.Order.MinOrderItems && orderItems.Count <= OrderModelConstants.Order.MaxOrderItems)
            .WithMessage($"Order must contain between {OrderModelConstants.Order.MinOrderItems} and {OrderModelConstants.Order.MaxOrderItems} items.");

        RuleForEach(o => o.OrderItems).SetValidator(new OrderItemValidator());
    }
}

public class OrderItemValidator : AbstractValidator<OrderItemModel>
{
    public OrderItemValidator()
    {
        RuleFor(oi => oi.ProductId)
            .GreaterThanOrEqualTo(OrderModelConstants.OrderItem.MinProductIdLength).WithMessage($"Product ID must be at least {OrderModelConstants.OrderItem.MinProductIdLength}.")
            .LessThanOrEqualTo(OrderModelConstants.OrderItem.MaxProductIdLength).WithMessage($"Product ID must be at most {OrderModelConstants.OrderItem.MaxProductIdLength}.");

        RuleFor(oi => oi.Quantity)
            .GreaterThanOrEqualTo(OrderModelConstants.OrderItem.MinQuantity).WithMessage($"Quantity must be at least {OrderModelConstants.OrderItem.MinQuantity}.")
            .LessThanOrEqualTo(OrderModelConstants.OrderItem.MaxQuantity).WithMessage($"Quantity must be at most {OrderModelConstants.OrderItem.MaxQuantity}.");
    }
}
