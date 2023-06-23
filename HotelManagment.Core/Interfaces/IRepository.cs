using System.Linq.Expressions;

namespace HotelManagment.Core;

public interface IRepository<T>
  where T : class
{
  T GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includeProperties = null, bool tracked = true);
  IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);
  Task AddAsync(T entity);
  void Remove(T entity);
  void RemoveRange(IEnumerable<T> entity);
}