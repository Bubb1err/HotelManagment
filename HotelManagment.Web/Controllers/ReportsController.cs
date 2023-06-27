using System.Security.Claims;
using AutoMapper;
using HotelManagment.Core.Entities;
using HotelManagment.Core.Interfaces.Services;
using HotelManagment.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagment.Web.Controllers;

[Authorize]
public class ReportsController : Controller
{
  private const string REPORT_VIEW = "Report";
  private const string ERROR_VIEW = "Error";
  private readonly IReportsService _reportsService;
  private readonly IMapper _mapper;

  public ReportsController(IReportsService reportsService, IMapper mapper)
  {
    _reportsService = reportsService;
    _mapper = mapper;
  }
  
  [HttpGet("[controller]")]
  public IActionResult All(int page = 1)
  {
    Result<IEnumerable<Report>> result = _reportsService.GetAll(page);
    return View(result.Data.ToList());
  }

  [HttpGet("Report/{id:guid}")]
  public async Task<IActionResult> GetById(int id)
  {
    Result<Report> result = await _reportsService.FindByIdAsync(id);

    if (!result.IsSucceeded)
    {
      return View(ERROR_VIEW, result.Errors);
    }

    return View(REPORT_VIEW, result.Data);
  }

  [HttpGet("Report/[action]")]
  public IActionResult Create()
  {
    return View();
  }

  [HttpPost("Report/[action]")]
  public async Task<IActionResult> Create(CreateReportVm reportVm)
  {
    if (!ModelState.IsValid)
    {
      return View(reportVm);
    }

    Report report = _mapper.Map<Report>(reportVm);
    report.ProblemSolverId = User.Claims.Single(claim => claim.Type == ClaimTypes.NameIdentifier).Value;

    Result result = await _reportsService.CreateAsync(report);

    if (!result.IsSucceeded)
    {
      foreach (string error in result.Errors)
      {
        ModelState.AddModelError("", error);
      }

      return View(reportVm);
    }
    
    return RedirectToAction(nameof(GetById), new { report.Id });
  }
}

