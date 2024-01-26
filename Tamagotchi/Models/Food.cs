using System;
using System.Timers;
using System.Collections.Generic;
using System.Windows;
using System.Linq;

namespace Tamagotchis.Models
{
  public class Food {

    public string Name { get; set; }
    public int Fullness {get;set;}
    public int Id {get;}
    private static int nextId = 1;
    private static List<Food> _instances = new List<Food>();

    public Food(string name) {
      Name = name;
      SetFullnessBasedOnName();
      _instances.Add(this);
      Id = nextId;
      nextId++;
    }

    private static Dictionary<string, int> FullnessDictionary = new Dictionary<string, int>
    {
      {"kibble", 10},
      {"canned", 20},
      {"filet-mignon", 35}
    };
    
    public static List<Food> GetAll()
    {
      return _instances;
    }

    public static Food Find(int searchId)
    {
      return _instances.FirstOrDefault(Food => Food.Id == searchId);
    }

    public static void Delete(int foodId)
    {
      var foodToDelete = _instances.FirstOrDefault(f => f.Id == foodId);
      if (foodToDelete != null)
      {
        _instances.Remove(foodToDelete);
      }
    }

    public static Dictionary<string,int> GetFood()
    {
      return FullnessDictionary;
    }
    private void SetFullnessBasedOnName()
    {
      if (FullnessDictionary.ContainsKey(Name))
      {
        Fullness = FullnessDictionary[Name];
      }
      else
      {
        Fullness = 0;
      }
    }
  }
}