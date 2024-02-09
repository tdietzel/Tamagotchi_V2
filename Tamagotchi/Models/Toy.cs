using System;
using System.Timers;
using System.Collections.Generic;
using System.Windows;
using System.Linq;

namespace Tamagotchis.Models
{
  public class Toy {
    public Shop Shop { get; set; }
    public int ShopId { get; set; }
    public int ToyId { get; set; }

    public string Name { get; set; }
    public int Excitement { get; set; }
    public string ItemType { get; set; }
    public int Quantity { get; set; }
    public bool purchasedSuccessfully = false;
  }
}