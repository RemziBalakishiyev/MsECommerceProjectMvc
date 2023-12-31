﻿using Entity.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccessLayer.Abstract;

public interface IGenericRepository<TEntity> where TEntity : class, IBaseTable, new()
{

    DbSet<TEntity> Table  { get; }
    Task<bool> AddAsync(TEntity entity);
    Task<bool> AddRangeAsync(ICollection<TEntity> entities);
    bool Remove(TEntity entity);
    bool RemoveRange(ICollection<TEntity> entities);
    bool Update(TEntity entity);

    void SaveChanges();

    Task<IEnumerable<TEntity>> GetAll(bool track = false);
  
    IQueryable<TEntity> GetById(int Id);
    IQueryable<TEntity> GetWhere(Expression<Func<TEntity,bool>> expression);
}
