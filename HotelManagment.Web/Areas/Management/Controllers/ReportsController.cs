using HotelManagment.Core.Entities;
using HotelManagment.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagment.Web.Areas.Management.Controllers;

[Area("Management")]
public class ReportsController : Controller
{
  private readonly IReportsService _reportsService;

  public ReportsController(IReportsService reportsService)
  {
    _reportsService = reportsService;
  }
  
  public IActionResult All()
  {
    Result<IEnumerable<Report>> result = _reportsService.GetAll();
    return View(result.Data);
  }
}