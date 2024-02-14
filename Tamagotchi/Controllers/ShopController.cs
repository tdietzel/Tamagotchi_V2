using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;
using Tamagotchis.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace Tamagotchis.Controllers
{
  public class ShopController : Controller
  {
    private readonly TamagotchiContext _db;
    private readonly UserManager<User> _userManager;
    public ShopController(TamagotchiContext db, UserManager<User> userManager)
    {
      _db = db;
      _userManager = userManager;
    }

    [HttpGet("/shop")]
    public async Task<ActionResult> Show()  
    {

      string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      User currentUser = await _userManager.FindByIdAsync(userId);

      Shop shop = _db.Shops
        .Include(shop => shop.Toys)
        .Include(shop => shop.Foods)
      .FirstOrDefault();

      ViewBag.User = currentUser;
      return View(shop);
    }

    //some changes below
    [HttpPost("/shop/buyFood")]
    public async Task<ActionResult> PurchaseFood(int foodId, string userId)
    {
      User user = await _userManager.FindByIdAsync(userId);
      Food food = _db.Foods.Find(foodId);

      double cost = Math.Round(food.Fullness / 2.0);

      if (user.Money >= cost)
      {
        user.Money -= cost;
        
        Food selectedFood = _db.Foods.Find(foodId);
        if (selectedFood != null)
        {
          user.FoodInventory.Add(selectedFood);
          Console.WriteLine("👽👽👽👽👽👽👽👽");
          Console.WriteLine(user.FoodInventory[0].Name);
          Console.WriteLine(user.FoodInventory[0].Fullness);
          // selectedFood.Quantity += 1;
        }
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