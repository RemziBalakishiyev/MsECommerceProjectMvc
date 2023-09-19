using DataAccessLayer.Abstract.Customers;
using DataAccessLayer.Concrete.EntityFrameworkCore.Context;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete.EntityFrameworkCore.Repositories.CustomerRepsository;

internal class EfProductRepository : EfGenericRepository<Product>,IProductRepository
{
    public EfProductRepository(MsECommerceContext context) : base(context)
    {
    }

    public IEnumerable<Product> GetWithCategory()
    {
        return Table.Include(x => x.Category).ToList();
    }
}
