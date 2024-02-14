using System;
using System.Timers;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tamagotchis.Models
{
  public class Toy {
    [Key]
    public int ToyId { get; set; }

    [ForeignKey("Shop")]
    public int ShopId { get; set; }
    public Shop Shop { get; set; }

    public string Name { get; set; }
    public int Excitement { get; set; }
    public string ItemType { get; set; }
    public bool purchasedSuccessfully = false;
  }
}