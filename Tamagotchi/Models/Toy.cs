using System;
using System.Timers;
using System.Collections.Generic;
using System.Windows;
using System.Linq;

namespace Tamagotchis.Models
{
  public class Toy {
    public string Name { get; set; }
    public int Excitement { get; set; }

    private bool purchasedSuccessfully = false;

    public int Id { get; set; }
    private static int nextId = 1;
    private static List<Toy> _instances = new List<Toy>();

    private static Dictionary<string, int> ExcitementDictionary = new Dictionary<string, int>
    {
      {"Ball", 20},
      {"Bone", 30},
      {"frisbee", 50}
    };

    // Constructor
    public Toy(string name) {
      Name = name;
      SetExcitementBasedOnName();
    }
    private void SetExcitementBasedOnName()
    {
      Excitement = ExcitementDictionary.ContainsKey(Name) ? ExcitementDictionary[Name] : 0;
    }
    public void AddToInstances()
    {
      if (purchasedSuccessfully)
      {
        Id = nextId;
        nextId++;
        _instances.Add(this);
      }
    }

    // Toy Management
    public static Toy Find(int searchId)
    {
      return _instances.FirstOrDefault(Toy => Toy.Id == searchId);
    }
    public static Dictionary<string,int> GetToys()
    {
      return ExcitementDictionary;
    }
    public static List<Toy> GetAll()
    {
      return _instances;
    }

    public bool Buy(string toyId)
    {
      var toyValue = ExcitementDictionary[toyId];
      int toyCost = (int)Math.Floor((double)toyValue / 2);

      if (Shop.Money >= toyCost)
      {
        Shop.Money -= toyCost;
        purchasedSuccessfully = true;
        return true;
      }
      else
      {
        purchasedSuccessfully = false;
        return false;
      }
    }
  }
}