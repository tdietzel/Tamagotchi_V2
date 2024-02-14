using System;
using System.Timers;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tamagotchis.Models
{
  public class Shop
  {
    [Key]
    public int ShopId { get; set; }
    public List<Toy> Toys { get; set; }
    public List<Food> Foods { get; set; }
  }
}