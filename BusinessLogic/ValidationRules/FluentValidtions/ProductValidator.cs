using BusinessLogic.Models;
using FluentValidation;

namespace BusinessLogic.ValidationRules.FluentValidtions;

public class ProductValidator : AbstractValidator<AddProductModel>
{
    public ProductValidator()
    {
        RuleFor(x => x.ProductName)
            .NotNull()
            .NotEmpty()
            .WithMessage("Product name can't be null");

        RuleFor(x => x.UnitPrice)
            .LessThan(100000)
            .GreaterThan(10)
            .WithMessage("Unit Price must be between 10-100");

        RuleFor(x => x.Size)
            .LessThan(100)
            .GreaterThan(1)
            .WithMessage("Size must be between 10-100");

        RuleFor(x => x.CategoryId)
            .NotNull()
            .NotEmpty()
            .WithMessage("Product name can't be null");

    }
}
