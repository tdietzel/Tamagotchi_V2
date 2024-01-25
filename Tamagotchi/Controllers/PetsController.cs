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
    public ActionResult Index()
    {
      List<Pet> allPets = Pet.GetAll();
      return View(allPets);
    }
    [HttpGet("/pets/{id}")]
    public ActionResult Show(int id)
    {
      Pet foundPet = Pet.Find(id);
      if (foundPet != null)
      {
        return View(foundPet);
      }
      return RedirectToAction("Index");
    }
    [HttpPost("/pets/action")]
    public ActionResult Perform(int petId, string action)
    {
      Pet foundPet = Pet.Find(petId);
      if (foundPet != null)
      {
        switch (action)
        {
          case "feed":
            foundPet.Feed(20);
            break;
          case "sleep":
            foundPet.Sleep();
            break;
          case "play":
          if (foundPet.Energy > 2)
          {
            foundPet.Play();
            break;
          }
          else
          {
            TempData["LowEnergyAlert"] = "Your pet is too tired to play!";
            break;
          }
          case "delete":
          Pet.Delete(petId);
          return RedirectToAction("Index");
        }
      }
      return RedirectToAction("Show", new { id = petId });
    }
  }
}