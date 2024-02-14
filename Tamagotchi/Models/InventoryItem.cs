// #nullable enable
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tamagotchis.Models;

namespace Tamagotchis.Models
{
  public class InventoryItem
  {
    [Key]
    public int InventoryItemId { get; set; }

    [ForeignKey("Inventory")]
    public string InventoryId { get; set; }
    public Inventory Inventory { get; set; }

    [ForeignKey("Toy")]
    public int? ToyId { get; set; }
    public Toy Toy { get; set; }

    [ForeignKey("Food")]
    public int? FoodId { get; set; }
    public Food Food { get; set; }

    public string Type { get; set; }
    public int Quantity { get; set; }
  }
}