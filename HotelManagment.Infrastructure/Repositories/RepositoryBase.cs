using HotelManagment.Infrastructure.Data;
using HotelManagment.Core;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace HotelManagment.Infrastructure.Repositories;

public abstract class RepositoryBase<T> : IRepository<T>
  where T : class
{
  protected readonly HotelDbContext _db;
  protected DbSet<T> dbSet;

  public RepositoryBase(HotelDbContext db)
  {
    _db = db;
    dbSet = _db.Set<T>();
  }
  public virtual async Task AddAsync(T entity)
  {
    await dbSet.AddAsync(entity);
  }
  public virtual IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
  {
    IQueryable<T> query = dbSet;
    if (filter != null)
    {
      query = query.Where(filter);
    }
    if (includeProperties != null)
    {
      foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
      {
        query = query.Include(includeProp);
      }
    }
    return query;
  }

  public virtual T GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includeProperties = null, bool tracked = true)
  {
    if (tracked)
    {
      IQueryable<T> query = dbSet;
      return Filtering(query, filter, includeProperties);
    }
    else
    {
      IQueryable<T> query = dbSet.AsNoTracking();
      return Filtering(query, filter, includeProperties);
    }

  }

  public virtual void Remove(T entity)
  {
    dbSet.Remove(entity);
  }

  public virtual void RemoveRange(IEnumerable<T> entity)
  {
    dbSet.RemoveRange(entity);
  }
  protected virtual T Filtering(IQueryable<T> query, Expression<Func<T, bool>> filter, string? includeProperties)
  {

    query = query.Where(filter);
    if (includeProperties != null)
    {
      foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
      {
        query = query.Include(includeProp);
      }
    }
    return query.FirstOrDefault();
  }

}