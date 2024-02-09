using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;
using Tamagotchis.Models;

namespace Tamagotchis.Controllers
{
  public class ShopController : Controller
  {
    private readonly TamagotchiContext _db;
    public ShopController(TamagotchiContext db)
    {
      _db = db;
    }

    [HttpGet("/shop")]
    public ActionResult Show(int id) 
    {
      User user = _db.Users.Find(id);

      Shop shop = _db.Shops
        .Include(shop => shop.Toys)
        .Include(shop => shop.Foods)
      .FirstOrDefault();
      ViewBag.User = user;
      return View(shop);
    }

    //some changes below
    // [HttpPost("/shop/buyFood")]
    [HttpPost]
    public ActionResult PurchaseFood(int foodId, int userId)
    {
      Food food = _db.Foods.Find(foodId);
      User user = _db.Users.Find(userId);
      double cost = Math.Round(food.Fullness / 2.0);

      if (user.Money >= cost)
      {
        user.Money -= cost;
        
        // var inventoryItem = _db.InventoryItems.FirstOrDefault(i => i.ItemId == foodId && i.UserId == userId && i.ItemType == "Food");
        // if (inventoryItem != null)
        // {
        //   inventoryItem.Quantity += 1;
        // }
        // else
        // {
        //   _db.InventoryItems.Add(new InventoryItem { UserId = userId, ItemId = food.FoodId, ItemType = "Food", Quantity = 1});
        // }

        _db.SaveChanges();
        //redirect for success
      }
      else
      {
        //redirect for not enough money
      }
      return RedirectToAction("Show");
    }
    
    // //altered to hopefully work with userId
    // [HttpPost("/shop/buyToy")]
    // public ActionResult PurchaseToy(string toyId, int userId)
    // {
    //   var toy = _db.Toys.Find(toyId);
    //   var user = _db.Users.Find(userId);

    //   if (user.Money >= toy.Cost)
    //   {
    //     user.Toy -= toy.Cost;

    //     var inventoryItem = db.InventoryItems.FirstOrDefault(i => i.ItemId == toyId && i.UserId == userId && i.ItemType = "Toy");
    //     if (inventoryItem != null)
    //     {
    //       inventoryItem.Quantity += 1;
    //     }
    //     else
    //     {
    //       _db.InventoryItems.Add(new InventoryItem { UserId = userId, ItemId = toy.ToyId, ItemType = "Toy", Quantity = 1});
    //     }

    //     _db.SaveChanges();
    //     //redirect successful purchase
    //   }
    //   else
    //   {
    //     //redirect for broke
    //   }
    // }
    
    // // {
    // //   Toy newPurchase = new Toy(toyId);

    // //   if (newPurchase.Buy(toyId))
    // //   {
    // //     newPurchase.AddToInstances();
    // //   }
      
    // //   return RedirectToAction("Show");
    // // }
  }
}