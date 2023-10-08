using BusinessLogic.Models.CategoryModels;

namespace BusinessLogic.Abstract;

public interface ICategoryService
{
    Task<IEnumerable<CategoryModel>> GetAll();
    Task<bool> AddCategory(CategoryModel categoryModel);
    Task<CategoryModel> GetById(int id);
    Task<bool> Remove(int id);
}
