using BusinessLogic.Models;

namespace BusinessLogic.Abstract;

public interface IProductService
{
    Task<bool> AddProduct(AddProductModel productModel);
}
