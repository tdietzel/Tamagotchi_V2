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

    [HttpPost("/shop/buyFood")]
    public async Task<ActionResult> PurchaseFood(int foodId, string userId)
    {
      User user = await _userManager.FindByIdAsync(userId);
      Food food = _db.Foods.Find(foodId);

      double cost = Math.Round(food.Fullness / 2.0);

      if (user.Money >= cost)
      {
        user.Money -= cost;
        
        InventoryItem newItem = new InventoryItem
        {
          InventoryId = user.Id,
          FoodId = food.FoodId,
          Quantity = 1,
          Type = "Food"
        };
        
        _db.InventoryItems.Add(newItem);
        _db.SaveChanges();
      }
      else
      {
        //redirect for not enough money
      }
      return RedirectToAction("Show");
    }

    [HttpPost("/shop/buyToy")]
    public async Task<ActionResult> PurchaseToy(int toyId, string userId)
    {
      User user = await _userManager.FindByIdAsync(userId);
      Toy toy = _db.Toys.Find(toyId);

      double cost = Math.Round(toy.Excitement / 2.0);

      if (user.Money >= cost)
      {
        user.Money -= cost;
        
        InventoryItem newItem = new InventoryItem
        {
          InventoryId = user.Id,
          ToyId = toy.ToyId,
          Quantity = 1,
          Type = "Toy"
        };

        _db.InventoryItems.Add(newItem);
        _db.SaveChanges();
      }
      else
      {
        //redirect for not enough money
      }
      return RedirectToAction("Show");
    }
  }
}