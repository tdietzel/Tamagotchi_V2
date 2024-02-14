using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
namespace Tamagotchis.Models
{
  public class Inventory
  {
    [Key]
    [ForeignKey("User")]
    public string UserId { get; set; }
    public User User { get; set; }

    public List<InventoryItem> Items { get; set; }
  }
}