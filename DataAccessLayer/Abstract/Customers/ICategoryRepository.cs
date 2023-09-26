using Entity.Concrete.Customer;

namespace DataAccessLayer.Abstract.Customers;

public interface  ICategoryRepository:IGenericRepository<Category>
{
    void Test();
}
