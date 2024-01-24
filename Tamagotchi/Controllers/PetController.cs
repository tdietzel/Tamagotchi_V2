using Microsoft.AspNetCore.Mvc;
using Tamagotchis.Models;

namespace Tamagotchis.Controllers
{
  public class PetController : Controller
  {
    [Route("/pets")]
    public ActionResult Index(string petName)
    {
      Pet newPet = new Pet(petName);
      return View(newPet);
    }
  }
}