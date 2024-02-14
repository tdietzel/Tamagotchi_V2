using System;
using System.Timers;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tamagotchis.Models
{
  public class Food {
    [Key]
    public int FoodId { get; set; }

    [ForeignKey("Shop")]
    public int ShopId { get; set; }
    public Shop Shop { get; set; }

    public string Name { get; set; }
    public int Fullness { get; set; }
    public string ItemType { get; set; }
    public bool purchasedSuccessfully = false;

    // private void SetFullnessBasedOnName()
    // {
    //   Fullness = FullnessDictionary.ContainsKey(Name) ? FullnessDictionary[Name] : 0;
    // }
  }
}