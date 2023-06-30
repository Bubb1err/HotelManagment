using Microsoft.AspNetCore.Mvc;

namespace HotelManagment.Web.Controllers;

public class HomeController : Controller
{
  // GET
  public IActionResult Index()
  {
    return View();
  }
}