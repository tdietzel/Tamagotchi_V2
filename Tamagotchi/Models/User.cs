using System;
using System.Timers;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using Tamagotchis.Models;

namespace Tamagotchis.Models
{
  public class User
  {
    public string UserName { get; set; }
    public int UserId { get; set; }

    public List<Pet> Pets { get; set; }
  }
}