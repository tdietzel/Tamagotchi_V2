using System;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Linq;

using Tamagotchis.Models;

namespace Tamagotchis.Controllers
{
  public class PetsController : Controller
  {
    private readonly TamagotchiContext _db;
    
    public PetsController(TamagotchiContext db)
    {
      _db = db;
    }

    [HttpGet("/Pets/{id}")]
    public ActionResult Index(int id)
    {
      List<Pet> model = _db.Pets
        .Include(pet => pet.User)
        .Where(pet => pet.UserId == id)
      .ToList();

      ViewBag.UserId = id;
      return View(model);
    }
    [HttpGet("/Pets/Create/{id}")]
    public ActionResult Create(int id)
    {
      ViewBag.UserId = id;
      return View();
    }
    [HttpPost("/Pets/Create/{id}")]
    public ActionResult Create(Pet pet)
    {
      //validation here maybe??
      _db.Pets.Add(pet);
      _db.SaveChanges();

      return RedirectToAction("Index", new { id = pet.UserId}); //CHANGE
    }

    [HttpGet("/Pets/Show/{id}")]
    public ActionResult Show(int id)
    {
      Pet thisPet = _db.Pets.FirstOrDefault(PetsController => PetsController.PetId == id);
      if (thisPet != null)
      {
        return View(thisPet);
      }
      return RedirectToAction("Index", new { id = id });
    }

    private ActionResult PerformAction(int petId, int userId, string action, string redirectToAction)
    {
      Pet foundPet = _db.Pets.FirstOrDefault(pet => pet.PetId == petId);

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
                    foundPet.Play(10);
                }
                else
                {
                    TempData["LowEnergyAlert"] = "Your pet is too tired to play!";
                }
                break;
          }

          _db.Pets.Update(foundPet);
          _db.SaveChanges();
      }

      return RedirectToAction(redirectToAction, new { id = userId });
    }

    [HttpPost("/pets/action/bury")]
    public ActionResult BuryAction(int petId, int userId, string action)
    {
      return PerformAction(petId, userId, action, "Show");
    }

    [HttpPost("/pets/action/eating")]
    public ActionResult EatingAction(int petId, int userId, string action)
    {
      return PerformAction(petId, userId, action, "Index");
    }

    [HttpPost("/pets/action/sleeping")]
    public ActionResult SleepingAction(int petId, int userId, string action)
    {
      return PerformAction(petId, userId, action, "Index");
    }

    [HttpPost("/pets/action/playing")]
    public ActionResult PlayingAction(int petId, int userId, string action)
    {
      return PerformAction(petId, userId, action, "Index");
    }

    public ActionResult Abandon(int petId)
    {
      var petToAbandon = _db.Pets.Find(petId);
      if (petToAbandon != null)
      {
        _db.Pets.Remove(petToAbandon);
        _db.SaveChanges();
      }
      return RedirectToAction("Index", new { id = petId });
    }
    
    [HttpPost]
    public IActionResult Hatch(int petId)
    {
      var pet = _db.Pets.FirstOrDefault(p => p.PetId == petId);
      if (pet != null && !pet.IsHatched)
      {
        Random random = new Random();
        int randomNumber = random.Next(1, 3);

        if (randomNumber == 1)
        {
          pet.Type = "Dog";
        }
        else
        {
          pet.Type = "Cat";
        }

        pet.IsHatched = true;
        _db.SaveChanges();
      }

      return RedirectToAction("Index", new { id = petId });
    }

    // [HttpGet("pets/show/{id}")]
    // public ActionResult ShowPets (int id)
    // {
    //   Pet thisPet = _db.Pets.FirstOrDefault(PetsController => PetsController.PetId == id);
    //   if (thisPet != null)
    //   {
    //     return View(thisPet);
    //   }
    //   return RedirectToAction("Index");
    // }
  }
}