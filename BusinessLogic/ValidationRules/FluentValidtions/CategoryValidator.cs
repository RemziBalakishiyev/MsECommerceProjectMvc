using BusinessLogic.Models;
using FluentValidation;

namespace BusinessLogic.ValidationRules.FluentValidtions;

public class CategoryValidator:AbstractValidator<CategoryModel>
{
    public CategoryValidator()
    {
        RuleFor(x => x.CategoryName)
            .NotEmpty()
            .NotNull()
            .WithMessage("Category name can`t be null");
    }
}
