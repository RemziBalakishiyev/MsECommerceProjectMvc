using BusinessLogic.Models.CategoryModels;

namespace BusinessLogic.Abstract;

public interface ICategoryService
{
    Task<IEnumerable<CategoryModel>> GetAll();
    Task<bool> AddCategory(CategoryModel categoryModel);
}
