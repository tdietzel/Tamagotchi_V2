using System;
using System.Timers;
using System.Collections.Generic;
using System.Windows;
using System.Linq;

namespace Tamagotchis.Models
{
  public class Food {
    public string Name { get; set; }
    public int Fullness { get; set; }

    public int Id { get; set; }
    private static int nextId = 1;
    private static List<Food> _instances = new List<Food>();

    private static Dictionary<string, int> FullnessDictionary = new Dictionary<string, int>
    {
      {"kibble", 10},
      {"canned", 20},
      {"filet-mignon", 35}
    };

    // Constructor
    public Food(string name) {
      Name = name;
      SetFullnessBasedOnName();
      AddToInstances();
    }
    private void SetFullnessBasedOnName()
    {
      Fullness = FullnessDictionary.ContainsKey(Name) ? FullnessDictionary[Name] : 0;
    }
    private void AddToInstances()
    {
      Id = nextId;
      nextId++;
      _instances.Add(this);
    }

    // Food Management
    public static Food Find(int searchId)
    {
      return _instances.FirstOrDefault(Food => Food.Id == searchId);
    }
    public static Dictionary<string,int> GetFood()
    {
      return FullnessDictionary;
    }
    public static List<Food> GetAll()
    {
      return _instances;
    }
    public static void Delete(int foodId)
    {
      var foodToDelete = _instances.FirstOrDefault(f => f.Id == foodId);
      if (foodToDelete != null)
      {
        _instances.Remove(foodToDelete);
      }
    }
  }
}