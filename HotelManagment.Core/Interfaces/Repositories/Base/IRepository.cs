using System.Linq.Expressions;

namespace HotelManagment.Core.Interfaces.Repositories.Base;

public interface IRepository<T>
  where T : class
{
  // GET
  IQueryable<T> Get();
  IQueryable<T> Get(Expression<Func<T, bool>> expression);
  Task<T?> TryFindAsync(Expression<Func<T, bool>> expression);

  // CREATE
  Task CreateAsync(T entity);

  // UPDATE
  Task UpdateAsync(T entity);

  // DELETE
  Task DeleteAsync(T entity);
}