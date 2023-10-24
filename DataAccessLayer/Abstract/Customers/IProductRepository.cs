using Entity.Concrete;

namespace DataAccessLayer.Abstract.Customers;

public interface IProductRepository:IGenericRepository<Product>
{
    Task<IEnumerable<Product>> GetAllProducts();
    IEnumerable<Product> GetWithCategory();
   
}
