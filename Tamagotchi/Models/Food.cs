using System;
using System.Timers;
using System.Collections.Generic;
using System.Windows;
using System.Linq;

namespace Tamagotchis.Models
{
  public class Food {
    public Shop Shop { get; set; }
    public int ShopId { get; set; }
    public int FoodId { get; set; }

    public string Name { get; set; }
    public int Fullness { get; set; }
    public string ItemType { get; set; }
    public int Quantity { get; set; }
    public bool purchasedSuccessfully = false;

    // private void SetFullnessBasedOnName()
    // {
    //   Fullness = FullnessDictionary.ContainsKey(Name) ? FullnessDictionary[Name] : 0;
    // }
  }
}