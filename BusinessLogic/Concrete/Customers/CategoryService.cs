using AutoMapper;
using BusinessLogic.Abstract;
using BusinessLogic.Models.CategoryModels;
using DataAccessLayer.Abstract.Customers;
using DataAccessLayer.Concrete.EntityFrameworkCore.Repositories.CustomerRepsository;
using Entity.Concrete.Customer;

namespace BusinessLogic.Concrete.Customers;

public class CategoryService : ICategoryService
{

    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<bool> AddCategory(CategoryModel categoryModel)
    {
        if (categoryModel is null)
        {
            return false;
        }


        var category = _mapper.Map<Category>(categoryModel);
        var addedData = await _categoryRepository.AddAsync(category);
        await _categoryRepository.SaveChanges();
        return true;
    }

    public async Task<IEnumerable<CategoryModel>> GetAll()
    {
        var categoryModels = _mapper.Map<IEnumerable<CategoryModel>>(await _categoryRepository.GetAll());
        return categoryModels;
    }

    public async Task<CategoryModel> GetById(int id)
    {
        var categoryModel = _mapper.Map<CategoryModel>(await _categoryRepository.GetById(id));
        return categoryModel;
    }

    public async Task<bool> Remove(int id)
    {
        var deletedCategory = await _categoryRepository.GetById(id);

        if(deletedCategory is null)
        {
            return false;
        }

        _categoryRepository.Remove(deletedCategory);

        await _categoryRepository.SaveChanges();

        return true;
    }
}
