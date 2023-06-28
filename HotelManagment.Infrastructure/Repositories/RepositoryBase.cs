using HotelManagment.Infrastructure.Data;
using HotelManagment.Core.Interfaces.Repositories.Base;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace HotelManagment.Infrastructure.Repositories;

public abstract class RepositoryBase<T> : IRepository<T>
  where T : class
{
  protected readonly HotelDbContext _dbContext;

  protected RepositoryBase(HotelDbContext dbContext)
  {
    _dbContext = dbContext;
  }

  // GET
  public virtual IQueryable<T> Get()
  {
    return _dbContext.Set<T>().AsNoTracking();
  }

  public virtual IQueryable<T> Get(Expression<Func<T, bool>> expression)
  {
    return _dbContext.Set<T>().Where(expression).AsNoTracking();
  }

  public virtual async Task<T?> TryFindAsync(Expression<Func<T, bool>> expression)
  {
    return await _dbContext.Set<T>().FirstAsync(expression);
  }

  // CREATE
  public virtual async Task CreateAsync(T entity)
  {
    await _dbContext.Set<T>().AddAsync(entity);
    await _dbContext.SaveChangesAsync();
  }

  // UPDATE
  public virtual async Task UpdateAsync(T entity)
  {
    _dbContext.Set<T>().Update(entity);
    await _dbContext.SaveChangesAsync();
  }

  // DELETE
  public virtual async Task DeleteAsync(T entity)
  {
    _dbContext.Set<T>().Remove(entity);
    await _dbContext.SaveChangesAsync();
  }
}