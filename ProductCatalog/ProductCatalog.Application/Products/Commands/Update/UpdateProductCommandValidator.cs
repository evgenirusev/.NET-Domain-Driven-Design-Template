using FluentValidation;

public class UpdateProductCommandValidator : AbstractValidator<ProductCommand>
{
    public UpdateProductCommandValidator() 
        => Include(new ProductCommandValidator());
}