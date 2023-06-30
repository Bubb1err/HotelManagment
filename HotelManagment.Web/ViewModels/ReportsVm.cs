using HotelManagment.Core.Entities;

namespace HotelManagment.Web.ViewModels;

public class ReportsVm
{
  private const int Difference = 3;
  public static ReportsVm Empty => GetEmpty();
  public IEnumerable<Report> Reports { get; set; } = null!;
  public int PageCount { get; set; }
  public int CurrentPage { get; set; }

  public int LowBorder => CurrentPage - Difference < 1 ? 1 : CurrentPage - Difference;
  public int TopBorder => CurrentPage + Difference > PageCount ? PageCount : CurrentPage + Difference;

  private static ReportsVm GetEmpty()
  {
    ReportsVm emptyReports =  new ReportsVm()
    {
      Reports = Enumerable.Empty<Report>(),
      PageCount = 0,
      CurrentPage = 0
    };

    return emptyReports;
  }
}