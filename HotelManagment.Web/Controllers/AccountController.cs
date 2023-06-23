using AutoMapper;
using HotelManagment.Web.ViewModels;
using HotelManagment.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagment.Web.Controllers;

public class AccountController : Controller
{
  private readonly IMapper _mapper;

  public AccountController(IMapper mapper)
  {
    _mapper = mapper;
  }

  [HttpGet]
  public IActionResult Login()
  {
    return View();
  }

  [HttpPost]
  public IActionResult Login([FromForm] LoginUserVm userVm)
  {
    if (!ModelState.IsValid)
    {
      return View(userVm);
    }

    User user = _mapper.Map<User>(userVm);

    return RedirectToAction("Index");
  }
}