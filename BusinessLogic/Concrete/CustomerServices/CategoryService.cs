using BusinessLogic.Abstract;
using BusinessLogic.Models;
using DataAccessLayer.Abstract.Customers;
using Entity.Concrete.Customer;

namespace BusinessLogic.Concrete.CustomerServices;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<bool> AddNewCategory(CategoryModel categoryModel)
    {
        if (categoryModel is not null)
        {

            Category category = new()
            {
                Id = categoryModel.Id ?? 0,
                CategoryName = categoryModel.CategoryName
            };
            await _categoryRepository.AddAsync(category);
            _categoryRepository.SaveChanges();
            return true;
        }
        return false;
    }

    public async Task<IEnumerable<CategoryModel>> GetAll()
    {
        List<CategoryModel> categoryModels = new List<CategoryModel>();
        foreach (var category in await _categoryRepository.GetAll(true))
        {
            CategoryModel categoryModel = new()
            {
                Id = category.Id,
                CategoryName = category.CategoryName,

            };
            categoryModels.Add(categoryModel);
        };

        return categoryModels;
    }
}
