using BusinessLogic.Abstract;
using BusinessLogic.Models.CategoryModels;
using DataAccessLayer.Abstract.Customers;
using DataAccessLayer.Concrete.EntityFrameworkCore.Repositories.CustomerRepsository;
using Entity.Concrete.Customer;

namespace BusinessLogic.Concrete.Customers;

public class CategoryService : ICategoryService
{

    private readonly ICategoryRepository _categoryRepository;
    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<bool> AddCategory(CategoryModel categoryModel)
    {
        if (categoryModel is null)
        {
            return false;
        }

        Category category = new()
        {
            Id = categoryModel.Id ?? 0,
            CategoryName = categoryModel.CategoryName
        };

        var addedData = await _categoryRepository.AddAsync(category);
        await _categoryRepository.SaveChanges();
        return true;
    }

    public async Task<IEnumerable<CategoryModel>> GetAll()
    {
        IList<CategoryModel> categoryModels = new List<CategoryModel>();

        foreach (var category in await _categoryRepository.GetAll())
        {
            CategoryModel categoryModel = new()
            {
                Id = category.Id,
                CategoryName = category.CategoryName
            };
            categoryModels.Add(categoryModel);
        };

        return categoryModels;
    }
}
