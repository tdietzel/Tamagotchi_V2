using System;
using System.Timers;
using System.Collections.Generic;
using System.Windows;
using System.Linq;

namespace Tamagotchis.Models
{
  public class Shop
  {
    public static int Money { get; set; } = 200;
    public Dictionary<string, int> typesOfFood = Food.GetFood();
    public Dictionary<string, int> typesOfToy = Toy.GetToys();

    public void UseMoney (int amount) {
      Money -= amount;
    }
  }
  public class ShopViewModel
  {
    public Dictionary<string, int> TypesOfFood { get; set; }
    public Dictionary<string, int> TypesOfToy { get; set; }

    public int money { get; set; }
  }
}