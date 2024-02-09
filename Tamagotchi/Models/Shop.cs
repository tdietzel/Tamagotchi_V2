using System;
using System.Timers;
using System.Collections.Generic;
using System.Windows;
using System.Linq;

namespace Tamagotchis.Models
{
  public class Shop
  {
    public int ShopId { get; set; }
    public List<Toy> Toys { get; set; }
    public List<Food> Foods { get; set; }
  }
}