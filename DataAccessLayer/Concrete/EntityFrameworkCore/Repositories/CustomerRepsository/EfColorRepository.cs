using DataAccessLayer.Abstract.Customers;
using DataAccessLayer.Concrete.EntityFrameworkCore.Context;
using Entity.Concrete.Customer;

namespace DataAccessLayer.Concrete.EntityFrameworkCore.Repositories.CustomerRepsository;

public class EfColorRepository : EfGenericRepository<Color>, IColorRepository
{
    public EfColorRepository(MsECommerceContext context) : base(context)
    {
    }
}
