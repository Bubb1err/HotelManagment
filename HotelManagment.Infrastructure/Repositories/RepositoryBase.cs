using HotelManagment.Infrastructure.Data;
using HotelManagment.Shared;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace HotelManagment.Infrastructure.Repositories;

public abstract class RepositoryBase<T> : IRepository<T>
  where T : class
{
  protected readonly HotelDbContext _dbContext;

  public RepositoryBase(HotelDbContext dbContext)
  {
    _dbContext = dbContext;
  }

  // GET
  public virtual IQueryable<T> Get()
  {
    return _dbContext.Set<T>();
  }

  public virtual IQueryable<T> Get(Expression<Func<T, bool>> expression)
  {
    return _dbContext.Set<T>().Where(expression);
  }

  public virtual async Task<T?> TryFindAsync(Expression<Func<T, bool>> expression)
  {
    return await _dbContext.Set<T>().FindAsync(expression);
  }

  // CREATE
  public virtual void Create(T entity)
  {
    _dbContext.Set<T>().Entry(entity).State = EntityState.Added;
  }

  // UPDATE
  public virtual void Update(T entity)
  {
    _dbContext.Set<T>().Entry(entity).State = EntityState.Modified;
  }

  // DELETE
  public virtual void Delete(T entity)
  {
    _dbContext.Set<T>().Entry(entity).State = EntityState.Deleted;
  }
}