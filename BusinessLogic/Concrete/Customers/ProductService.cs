using AutoMapper;
using BusinessLogic.Abstract;
using BusinessLogic.Models.ProductModels;
using DataAccessLayer.Abstract.Customers;
using Entity.Concrete;

namespace BusinessLogic.Concrete.Customers;

public class ProductService : IProductService
{

    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<bool> Add(ProductModel productModel)
    {
        var product = _mapper.Map<Product>(productModel);

        
        await _productRepository.AddAsync(product);
        product.InStock = product.Quantity > 0;
        await _productRepository.SaveChanges();
        return true;
    }


    public async Task<IEnumerable<GetAllProduct>> GetAllProduct()
    {
        var productList = await _productRepository.GetAllProducts();
        var products = _mapper.Map<IEnumerable<GetAllProduct>>(productList);
        return products;

    }
}
