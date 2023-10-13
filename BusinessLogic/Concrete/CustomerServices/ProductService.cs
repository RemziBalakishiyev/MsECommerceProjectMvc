using AutoMapper;
using BusinessLogic.Abstract;
using BusinessLogic.Models;
using DataAccessLayer.Abstract.Customers;
using Entity.Concrete;

namespace BusinessLogic.Concrete.CustomerServices;

public class ProductService:IProductService
{

    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<bool> AddProduct(AddProductModel productModel)
    {

        var product =  _mapper.Map<Product>(productModel);  
        
        bool result = await _productRepository.AddAsync(product);

        _productRepository.SaveChanges();
        return result;
    }
}
