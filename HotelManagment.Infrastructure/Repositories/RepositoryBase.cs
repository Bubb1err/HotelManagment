using HotelManagment.Infrastructure.Data;
using HotelManagment.Core.Interfaces.Repositories.Base;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

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
    IQueryable<T> items = ApplyIncludes(_dbContext.Set<T>());

    return items.AsNoTracking();
  }

  public virtual IQueryable<T> Get(Expression<Func<T, bool>> expression)
  {
    IQueryable<T> items = ApplyIncludes(_dbContext.Set<T>().Where(expression));
    
    return items.AsNoTracking();
  }

  public virtual async Task<T?> TryFindAsync(Expression<Func<T, bool>> expression)
  {
    return await ApplyIncludes(_dbContext.Set<T>()).FirstAsync(expression);
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

  private IQueryable<T> ApplyIncludes(IQueryable<T> items)
  {
    foreach (INavigation navigation in _dbContext.Model.FindEntityType(typeof(T))!.GetNavigations())
    {
      items = items.Include(navigation.Name);
    }

    return items;
  }
}