using FluentAssertions;
using Xunit;

namespace ProductCatalog.Application.Tests.Products.Commands.Common;

public class ProductCommandValidatorTests
{
    private readonly ProductCommandValidator validator = new();

    [Fact]
    public void Validator_RejectsEmptyName_WithSpecificError()
    {
        var command = ValidCommand();
        command.Name = string.Empty;

        var result = validator.Validate(command);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(e => e.ErrorMessage == "Name is required.");
    }

    [Fact]
    public void Validator_RejectsZeroPrice()
    {
        var command = ValidCommand();
        command.Price = new PriceRequest(0m, "USD");

        var result = validator.Validate(command);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(e => e.PropertyName == "Price.Amount");
    }

    [Fact]
    public void Validator_AcceptsValidCommand()
    {
        var command = ValidCommand();

        var result = validator.Validate(command);

        result.IsValid.Should().BeTrue();
        result.Errors.Should().BeEmpty();
    }

    private static ProductCommand ValidCommand() => new()
    {
        Name = "Widget",
        Description = "A simple widget for testing.",
        ProductType = 1,
        Price = new PriceRequest(9.99m, "USD"),
        Weight = new WeightRequest(1.5m, "kg")
    };
}
