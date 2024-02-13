using Microsoft.AspNetCore.Identity;
using System;
using System.Timers;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using Tamagotchis.Models;

namespace Tamagotchis.Models
{
  public class User : IdentityUser
  {
    public string Name { get; set; }

    public double Money { get; set; }
    public List<Pet> Pets { get; set; }

    public User() {
      Money = 200;
    }
    // public List<Inventory> UserInventory { get; set; }
    // public List<Food> PurchasedFoods { get; set; }
    // public List<Toy> PurchasedToys { get; set; }

    // public Inventory()
    // {
    //   PurchasedFoods = new List<Food>();
    //   PurchasedFoods = new List<Toy>();
    // }

    // public void AddPurchasedFoods (Food food)
    // {
    //   UserInventory.PurchasedFoods.Add(food);
    // }

    // public void AddPurchasedToys (Toy toy)
    // {
    //   UserInventory.PurchasedToys.Add(toy);
    // }

    public void UseMoney (int amount) {
      Money -= amount;
    }
  }
}