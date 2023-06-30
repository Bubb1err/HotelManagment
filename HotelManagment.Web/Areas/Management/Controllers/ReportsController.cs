using AutoMapper;
using HotelManagment.Core.Entities;
using HotelManagment.Core.Interfaces.Services;
using HotelManagment.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagment.Web.Areas.Management.Controllers;

[Area("Management")]
public class ReportsController : Controller
{
  private readonly IReportsService _reportsService;
  private readonly IMapper _mapper;

  public ReportsController(IReportsService reportsService, IMapper mapper)
  {
    _reportsService = reportsService;
    _mapper = mapper;
  }
  
  [HttpGet]
  public IActionResult All([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
  {
    if (pageSize < 10)
    {
      pageSize = 10;
    }
    if (page < 1)
    {
      page = 1;
    }
    int pageCount = _reportsService.GetPageCount(pageSize);

    if (page > pageCount)
    {
      page = pageCount;
    }

    if (page == 0)
    {
      return View(ReportsVm.Empty);
    }
    
    Result<IEnumerable<Report>> result = _reportsService.GetAll(page, pageSize);
    ReportsVm reports = new ReportsVm
    {
      Reports = result.Data,
      PageCount = pageCount,
      CurrentPage = page
    };

    return View(reports);
  }
  
  [HttpGet("[area]/Report/{reportId:int}")]
  public async Task<IActionResult> GetById(int reportId)
  {
    Result<Report> report = await _reportsService.FindByIdAsync(reportId);

    if (!report.IsSucceeded)
    {
      return View("Error", report.Errors);
    }

    return View(report.Data);
  }

  [HttpPost("[area]/Report/Assign")]
  public IActionResult Assign([FromBody] AssignReportVm assignVm)
  {
    return Ok();
  }

  [HttpGet("[area]/Report/Create")]
  public IActionResult Create()
  {
    return View();
  }

  [HttpPost("[area]/Report/Create")]
  public async Task<IActionResult> Create([FromForm] CreateReportVm reportVm)
  {
    Report report = _mapper.Map<Report>(reportVm);

    Result result = await _reportsService.CreateAsync(report);
    
    return RedirectToAction(nameof(All));
  }
}