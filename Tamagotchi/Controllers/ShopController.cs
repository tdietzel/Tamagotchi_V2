using Microsoft.AspNetCore.Mvc;
using Tamagotchis.Models;

namespace Tamagotchis.Controllers
{
  public class ShopController : Controller
  {
    [HttpGet("/shop")]
    public ActionResult Shop() 
    {
      Shop shop = new Shop();
      ShopViewModel viewModel = new ShopViewModel
      {
        TypesOfFood = shop.typesOfFood,
        TypesOfToy = shop.typesOfToy
      };
      return View(viewModel);
    }

    [HttpPost("/shop/buyFood")]
    public ActionResult PurchaseFood(string foodId)
    {
      Food newPurchase = new Food(foodId);
      // Shop shop = new Shop();

      return RedirectToAction("Shop");
    }

    [HttpPost("/shop/buyToy")]
    public ActionResult PurchaseToy(string toyId)
    {
      Toy newPurchase = new Toy(toyId);
      // Shop shop = new Shop();
      return RedirectToAction("Shop");
    }
  }
}