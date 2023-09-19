using Entity.Concrete;

namespace DataAccessLayer.Abstract.Customers;

public interface IProductRepository:IGenericRepository<Product>
{
    IEnumerable<Product> GetWithCategory();
   
}
