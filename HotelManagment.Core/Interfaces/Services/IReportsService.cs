using System.Linq.Expressions;
using HotelManagment.Core.Entities;

namespace HotelManagment.Core.Interfaces.Services;

public interface IReportsService
{
  int GetPageCount(int pageSize = 10);
  Result<IEnumerable<Report>> GetAll(int page = 1, int pageSize = 10);
  Result<IEnumerable<Report>> GetAll(Expression<Func<Report, bool>> expression, int page = 1, int pageSize = 10);
  Task<Result<Report>> FindAsync(Expression<Func<Report, bool>> expression);
  Task<Result<Report>> FindByIdAsync(int id);
  
  Task<Result> CreateAsync(Report report);
  
  Task<Result> UpdateAsync(Report updatedReport);
  
  Task<Result> DeleteAsync(Report deletedReport);
}