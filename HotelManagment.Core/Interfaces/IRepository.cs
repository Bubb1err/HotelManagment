using System.Linq.Expressions;

namespace HotelManagment.Core.Interfaces;

public interface IRepository<T>
  where T : class
{
  // GET
  IQueryable<T> Get();
  IQueryable<T> Get(Expression<Func<T, bool>> expression);
  Task<T?> TryFindAsync(Expression<Func<T, bool>> expression);

  // CREATE
  void Create(T entity);

  // UPDATE
  void Update(T entity);

  // DELETE
  void Delete(T entity);
}