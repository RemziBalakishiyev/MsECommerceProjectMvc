using BusinessLogic.Abstract;
using BusinessLogic.Models;
using DataAccessLayer.Abstract.Customers;
using Entity.Concrete;

namespace BusinessLogic.Concrete.CustomerServices;

public class ProductService:IProductService
{

    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<bool> AddProduct(AddProductModel productModel)
    {

        Product product = new()
        {
            ProductName = productModel.ProductName,
            Quantity = productModel.Quantity,
            CategoryId = productModel.CategoryId,
            InStock = productModel.InStock,
            ProductDescription = productModel.ProductDescription,
            Size = productModel.Size,
            UnitPrice = productModel.UnitPrice,
        };
        bool result = await _productRepository.AddAsync(product);

        return result;
    }
}
