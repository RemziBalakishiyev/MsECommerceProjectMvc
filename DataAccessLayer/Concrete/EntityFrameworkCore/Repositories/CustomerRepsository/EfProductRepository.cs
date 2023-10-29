using DataAccessLayer.Abstract.Customers;
using DataAccessLayer.Concrete.EntityFrameworkCore.Context;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete.EntityFrameworkCore.Repositories.CustomerRepsository;

public class EfProductRepository : EfGenericRepository<Product>,IProductRepository
{
    public EfProductRepository(MsECommerceContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Product>> GetAllProducts()
    {
        return await Table
            .Include(x => x.Category)
            .Include(x => x.Colors)
            .ToListAsync();
    }

    public IEnumerable<Product> GetWithCategory()
    {
        return Table.Include(x => x.Category).ToList();
    }

   
}
