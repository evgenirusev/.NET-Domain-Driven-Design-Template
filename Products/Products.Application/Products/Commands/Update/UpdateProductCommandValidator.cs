using FluentValidation;

public class UpdateProductCommandValidator : AbstractValidator<ProductCommand>
{
    public UpdateProductCommandValidator() 
        => this.Include(new ProductCommandValidator());
}