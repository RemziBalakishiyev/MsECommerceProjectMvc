using BusinessLogic.Models.ProductModels;

namespace BusinessLogic.Abstract;

public interface IProductService
{
    Task<bool> Add(ProductModel productModel);
    Task<IEnumerable<GetAllProduct>> GetAllProduct();
}
