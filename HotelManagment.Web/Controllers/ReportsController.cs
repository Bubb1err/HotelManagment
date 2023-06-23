using Microsoft.AspNetCore.Mvc;

namespace HotelManagment.Web.Controllers
{
  public class ReportsController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }
  }
}
