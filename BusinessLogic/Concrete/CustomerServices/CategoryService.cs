using AutoMapper;
using BusinessLogic.Abstract;
using BusinessLogic.Models;
using DataAccessLayer.Abstract.Customers;
using Entity.Concrete.Customer;

namespace BusinessLogic.Concrete.CustomerServices;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<bool> AddNewCategory(CategoryModel categoryModel)
    {
        if (categoryModel is not null)
        {
            await _categoryRepository.AddAsync(_mapper.Map<Category>(categoryModel));
            _categoryRepository.SaveChanges();
            return true;
        }
        return false;
    }

    public async Task<IEnumerable<CategoryModel>> GetAll()
    {
        var categoryModels = _mapper.Map<List<CategoryModel>>(await _categoryRepository.GetAll(true));

        return categoryModels;
    }

    public  CategoryModel GetById(int id)
    {

        var result = _categoryRepository.GetWhere(x => x.Id == id).FirstOrDefault();
        var categoryModel = _mapper.Map<CategoryModel>(result);
        return categoryModel;
    }
}
