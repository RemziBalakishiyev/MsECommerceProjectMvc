using BusinessLogic.Models.CategoryModels;
using FluentValidation;

namespace BusinessLogic.ValidationRules.FluentValidation;

public class CategoryModelValidator:AbstractValidator<CategoryModel>
{
    public CategoryModelValidator()
    {
        RuleFor(x=>x.CategoryName)
            .NotEmpty()
            .NotNull()
            .WithMessage("Category Name can`t be null");
    }
}
