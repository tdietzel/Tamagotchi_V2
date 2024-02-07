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

    public ActionResult Index()
    {
      List<Pet> model = _db.Pets
      .Include(pet => pet.User) 
      .ToList();

      return View(model);
    }
    [HttpGet("/Pets/Create/{id}")]
    public ActionResult Create(int id)
    {
      Console.WriteLine("🤑🤑🤑🤑🤑🤑");
      Console.WriteLine(id);
      ViewBag.UserId = id;
      return View();
    }
    [HttpPost("/Pets/Create/{id}")]
    public ActionResult Create(Pet pet)
    {
      Console.WriteLine("👽👽👽👽👽👽");
      Console.WriteLine(pet.UserId);
      _db.Pets.Add(pet);
      _db.SaveChanges();

      return RedirectToAction("Index");
    }

    public ActionResult Show(int id)
    {
      Pet thisPet = _db.Pets.FirstOrDefault(PetsController => PetsController.PetId == id);
      if (thisPet != null)
      {
        return View(thisPet);
      }
      return RedirectToAction("Index");
    }

    private ActionResult PerformAction(int petId, string action, string redirectToAction)
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

      return RedirectToAction(redirectToAction);
    }

    [HttpPost("/pets/action/bury")]
    public ActionResult BuryAction(int petId, string action)
    {
      return PerformAction(petId, action, "Show");
    }

    [HttpPost("/pets/action/eating")]
    public ActionResult EatingAction(int petId, string action)
    {
      return PerformAction(petId, action, "Index");
    }

    [HttpPost("/pets/action/sleeping")]
    public ActionResult SleepingAction(int petId, string action)
    {
      return PerformAction(petId, action, "Index");
    }

    [HttpPost("/pets/action/playing")]
    public ActionResult PlayingAction(int petId, string action)
    {
      return PerformAction(petId, action, "Index");
    }

    public ActionResult Abandon(int petId)
    {
      var petToAbandon = _db.Pets.Find(petId);
      if (petToAbandon != null)
      {
        _db.Pets.Remove(petToAbandon);
        _db.SaveChanges();
      }
      return RedirectToAction("Index");
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

      return RedirectToAction("Index");
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