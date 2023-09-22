using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFrameworkCore.Context;
using Entity.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccessLayer.Concrete.EntityFrameworkCore;

public class EfGenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IBaseTable, new()
{

    private readonly MsECommerceContext _context;

    public EfGenericRepository(MsECommerceContext context)
    {
        _context = context;
    }

    public DbSet<TEntity> Table => _context.Set<TEntity>();

    public async Task<bool> AddAsync(TEntity entity)
    {
        var state = await Table.AddAsync(entity);
        return EntityState.Added == state.State;
    }

    public async Task<bool> AddRangeAsync(ICollection<TEntity> entities)
    {
        await Table.AddRangeAsync(entities);
        return true;
    }

    public async Task<IEnumerable<TEntity>> GetAll(bool track = false)
    {
        if (track is false)
        {
            return await Table.ToListAsync();
        }

        return await Table.AsNoTracking().ToListAsync();
        
    }

    public IQueryable<TEntity> GetById(int Id)
    {
        throw new NotImplementedException();
    }

    public IQueryable<TEntity> GetWhere(Expression<Func<TEntity, bool>> expression)
    {
        return Table.Where(expression);
    }

    public bool Remove(TEntity entity)
    {
        var state = Table.Remove(entity);
        return EntityState.Deleted == state.State;
    }

    public bool RemoveRange(ICollection<TEntity> entities)
    {
        Table.RemoveRange(entities);
        return true;
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

    public bool Update(TEntity entity)
    {
        var state = Table.Update(entity);
        return EntityState.Modified == state.State;
    }
}
