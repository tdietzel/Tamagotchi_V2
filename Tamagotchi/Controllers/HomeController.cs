using Microsoft.AspNetCore.Mvc;
using Tamagotchis.Models;

namespace Tamagotchis.Controllers
{
  public class HomeController : Controller
  {
    [HttpGet("/")]
    public ActionResult New() { return View(); }
  }
}