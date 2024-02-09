using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Routing;
using System;
using System.Linq;
using System.Collections.Generic;
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

      return RedirectToAction("Index", new { id = pet.UserId });
    }

    [HttpGet("/Pets/Show/{id}")]//trying to figure out how to debug this? I think this is where things might be going wrong with the missing first pet
    public ActionResult Show(int id)
    {
      Pet thisPet = _db.Pets.FirstOrDefault(pet => pet.PetId == id);//these were named wrong I think? used to be PetsController
      if (thisPet != null)
      {
        return View(thisPet);
      }
      else
      {
        return RedirectToAction("Index", new { userId = id });
      }

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
      Pet petToAbandon = _db.Pets.Find(petId);
      if (petToAbandon != null)
      {
        _db.Pets.Remove(petToAbandon);
        _db.SaveChanges();
      }

      return RedirectToAction("Index", new { id = petToAbandon.UserId });
    }

    [HttpPost]
    public IActionResult Hatch(int petId)
    {
      Pet pet = _db.Pets.FirstOrDefault(p => p.PetId == petId);
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

      return RedirectToAction("Index", new { id = pet.UserId });
    }


    // //Hypothetical feed function to work with inventory stuff
    // [HttpPost]
    // public ActionResult FeedPet(int PetId, int inventoryItemId)
    // {
    //   var pet = _db.Pets.Find(petId);
    //   var inventoryItem = _db.InventoryItems.Find(inventoryItemId);

    //   if (pet != null && inventoryItem != null && inventoryItem.ItemType == "Food")
    //   {
    //     pet.Feed(inventoryItem.ItemId); //may need to adjust pet model
    //     inventoryItem.Quantity -= 1;

    //     if (inventoryItem.Quantity <= 0)
    //     {
    //       _db.InventoryItems.Remove(inventoryItem);
    //     }
    //     _db.SaveChanges();
    //     //put a redirect here
    //   }
    //   else
    //   {
    //     //this pops up if errors happen
    //   }

    //   return RedirectToAction("Show", new { id=petId});

    // }

    // [HttpPost]
    // public ActionResult PlayPet(int PetId, int inventoryItemId)
    // {
    //   var pet = _db.Pets.Find(petId);
    //   var toyItem = _db.InventoryItems.Find(inventoryItemId);

    //   if (pet != null && toyItem != null && toyItem.ItemType == "Toy")
    //   {
    //     pet.Play(toyItem.ItemId); //may need to adjust pet stuff
    //     toyItem.Quantity -= 1;

    //     if (toyItem.Quantity <= 0)
    //     {
    //       _db.InventoryItems.Remove(toyItem);
    //     }
    //     _db.SaveChanges();
    //     //redirect for success
    //   }
    //   else 
    //   {
    //     //error!
    //   }

    //   return RedirectToAction("Show", new { id=petId });
    // }
  }
}