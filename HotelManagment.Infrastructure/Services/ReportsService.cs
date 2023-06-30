using System.Linq.Expressions;
using HotelManagment.Core.Entities;
using HotelManagment.Core.Interfaces.Repositories;
using HotelManagment.Core.Interfaces.Services;

namespace HotelManagment.Infrastructure.Services;

public class ReportsService : IReportsService
{
  private readonly IReportsRepository _reportsRepository;

  public ReportsService(IReportsRepository reportsRepository)
  {
    _reportsRepository = reportsRepository;
  }

  public int GetPageCount(int pageSize = 10)
  {
    int reportsCount = _reportsRepository.Get().Count();
    
    return (int)Math.Ceiling(1f * reportsCount / pageSize);
  }
  
  public Result<IEnumerable<Report>> GetAll(int page = 1, int pageSize = 10)
  {
    if (page < 1 || pageSize < 1)
    {
      return Result<IEnumerable<Report>>.Failure("Incorrect page/page size.");
    }
    IEnumerable<Report> reports = _reportsRepository
      .Get()
      .Skip((page - 1) * pageSize)
      .Take(pageSize);

    Result<IEnumerable<Report>> result = Result<IEnumerable<Report>>.Succeeded(reports);

    return result;
  }

  public Result<IEnumerable<Report>> GetAll(Expression<Func<Report, bool>> expression, int page = 1, int pageSize = 10)
  {
    if (page < 1 || pageSize < 1)
    {
      return Result<IEnumerable<Report>>.Failure("Incorrect page/page size.");
    }
    IEnumerable<Report> reports = _reportsRepository
      .Get(expression)
      .Skip((page - 1) * pageSize)
      .Take(pageSize);

    Result<IEnumerable<Report>> result = Result<IEnumerable<Report>>.Succeeded(reports);

    return result;
  }

  public async Task<Result<Report>> FindAsync(Expression<Func<Report, bool>> expression)
  {
    Report? report = await _reportsRepository.TryFindAsync(expression);
    if (report is null)
    {
      return Result<Report>.Failure("Report not found.");
    }

    return Result<Report>.Succeeded(report);
  }
  public async Task<Result<Report>> FindByIdAsync(int id)
  {
    return await FindAsync(report => report.Id == id);
  }

  public async Task<Result> CreateAsync(Report report)
  {
    report.Description = report.Description.Trim();
    
    await _reportsRepository.CreateAsync(report);

    return Result.Succeeded();
  }

  public async Task<Result> UpdateAsync(Report updatedReport)
  {
    Report? existedReport = await _reportsRepository.TryFindAsync(report => report.Id == updatedReport.Id);

    if (existedReport is null)
    {
      return Result.Failure("Report with that 'ID' not found.");
    }
    
    updatedReport.Description = updatedReport.Description.Trim();
    
    await _reportsRepository.UpdateAsync(updatedReport);

    return Result.Succeeded();
  }

  public async Task<Result> DeleteAsync(Report deletedReport)
  {
    Report? existedReport = await _reportsRepository.TryFindAsync(report => report.Id == deletedReport.Id);

    if (existedReport is null)
    {
      return Result.Failure("Report with that 'ID' not found.");
    }
    
    await _reportsRepository.DeleteAsync(deletedReport);

    return Result.Succeeded();
  }
}