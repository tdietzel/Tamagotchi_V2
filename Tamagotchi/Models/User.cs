using Microsoft.AspNetCore.Identity;
using System;
using System.Timers;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tamagotchis.Models;

namespace Tamagotchis.Models
{
  public class User : IdentityUser
  {
    public int InventoryId { get; set; }
    public Inventory Inventory { get; set; }

    public List<Pet> Pets { get; set; }
    public string Name { get; set; }
    public double Money { get; set; }

    public User()
    {
      Money = 200;
      Inventory = new Inventory();
    }

    public void UseMoney(int amount)
    {
      Money -= amount;
    }
  }
}