using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Tamagotchis.Models;


namespace Tamagotchis.Controllers
{
  public class PetsController : Controller
  {
    [HttpPost("/pets")]
    public ActionResult Create(string petName)
    {
      Pet newPet = new Pet(petName);
      return RedirectToAction("Index");
    }
    [HttpGet("/pets")]
    public ActionResult Index(string petName)
    {
      List<Pet> allPets = Pet.GetAll();
      return View(allPets);
    }
    [HttpGet("/pets/{id}")]
    public ActionResult Show(int id)
    {
      Pet foundPet = Pet.Find(id);
      return View(foundPet);
    }
  }
}