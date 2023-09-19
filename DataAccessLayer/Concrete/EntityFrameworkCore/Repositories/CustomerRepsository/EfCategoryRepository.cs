using DataAccessLayer.Abstract.Customers;
using DataAccessLayer.Concrete.EntityFrameworkCore.Context;
using Entity.Concrete.Customer;

namespace DataAccessLayer.Concrete.EntityFrameworkCore.Repositories.CustomerRepsository;

public class EfCategoryRepository : EfGenericRepository<Category>, ICategoryRepository
{
    public EfCategoryRepository(MsECommerceContext context) : base(context)
    {
    }
}
