using BusinessLogic.Models;

namespace BusinessLogic.Abstract;
public interface ICategoryService
{
    Task<bool> AddNewCategory(CategoryModel categoryModel);

    Task<IEnumerable<CategoryModel>> GetAll();
}