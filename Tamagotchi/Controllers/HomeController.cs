using Microsoft.AspNetCore.Mvc;
using Tamagotchis.Models;

namespace Tamagotchis.Controllers
{
  public class HomeController : Controller
  {
    [Route("/")]
    public ActionResult Index() { return View(); }
  }
}