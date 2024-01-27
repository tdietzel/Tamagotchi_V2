using System;
using System.Timers;
using System.Collections.Generic;
using System.Windows;
using System.Linq;

namespace Tamagotchis.Models
{
  public class Pet
  {
    // Inventory
    public static List<Food> _inventory = Food.GetAll();
    public static List<Toy> _inventoryToy = Toy.GetAll();

    // Controller Model
    public class FoodAndToyModel
    {
      public List<Food> FoodList {get; set;}
      public List<Toy> ToyList {get; set;}
    }

    // Pet Variables

    public string Name { get; private set; }

    public bool Alive { get; set; } = true;
    public int Age { get; set; }
    public string Type { get; set; }
    public int Id { get; }
    private static int nextId = 1;

    public int Fullness { get; set; }
    public int Energy { get; set; }
    public int Attention { get; set; }
    public int Weight { get; set; } = 1;


    // Timers
    private Timer ageTimer;
    private Timer incubationTimer;
    private Timer statTicker;
    private Timer feedTimer;
    private Timer sleepTimer;
    private Timer playTimer;

    // Pet Actions
    public bool IsHatched { get; set; } = false;
    public bool IsFeeding { get; set; } = false;
    public bool IsSleeping { get; set; } = false;
    public bool IsPlaying { get; set; } = false;


    // Pet Constructors
    private static List<Pet> _instances = new List<Pet> { };

    public Pet() : this("Jimmy Default") {}
    public Pet(string name)
    {
      Name = name;
      Type = Type;
      Fullness = 100;
      Energy = 0;
      Attention = 100;

      _instances.Add(this);
      Id = nextId;
      nextId++;

      InitializeTimers();
    }

    // Timers
    private void InitializeTimers()
    {
      ageTimer = new Timer();
      ageTimer.Interval = 600000; // 86400000; // 24 hours in milliseconds
      ageTimer.Elapsed += AgeTimerElapsed;
      ageTimer.Start();

      incubationTimer = new Timer();
      incubationTimer.Interval = 10000;
      incubationTimer.Elapsed += HatchTimerElapsed;
      incubationTimer.Start();

      statTicker = new Timer();
      statTicker.Interval = 10000;
      statTicker.Elapsed += StatTickerElapsed;
      statTicker.Start();
    }

    private void AgeTimerElapsed(object sender, ElapsedEventArgs e)
    {
      Age += 1;
    }
    private void HatchTimerElapsed(object sender, ElapsedEventArgs e)
    {
      IsHatched = true;

      Energy = 100;

      Random randomEgg = new Random();
      int randomResult = randomEgg.Next(1, 3);
      Type = randomResult == 1 ? "Dog" : "Cat";

      ((Timer)sender).Stop();
    }
    private void StatTickerElapsed(object sender, ElapsedEventArgs e)
    {
      DecreaseAttributes();
    }

    private void FeedTimerElapsed(object sender, ElapsedEventArgs e)
    {
      IsFeeding = false;

      Fullness += 20;
      Fullness = Fullness > 100 ? Fullness = 100 : Fullness;

      ((Timer)sender).Stop();
    }
    private void SleepTimerElapsed(object sender, ElapsedEventArgs e)
    {
      IsSleeping = false;

      Energy = 100;

      ((Timer)sender).Stop();
    }

    private void PlayTimerElapsed(object sender, ElapsedEventArgs e)
    {
      IsPlaying = false;

      Fullness = Fullness < 5 ? Fullness = 0 : Fullness;

      if (Energy < 5)
      {
        Energy = 0;
      }
      else
      {
        Fullness -= 5;
        Energy -= 20;
        Attention = Attention < 50 ? Attention += 50 : Attention = 100;
      }

      CheckIfDead();
      ((Timer)sender).Stop();
    }

    // Vitals Control
    private void CheckIfDead()
    {
      if (Fullness == 0)
      {
        Alive = false;
        statTicker.Stop();

        Energy = 0;
        Attention = 0;
      }
    }
    private void DecreaseAttributes()
    {
      Energy -= 2;
      Fullness -= 2;
      Attention -= 2;

      if (Energy <= 0)
      {
        Energy = 0;
        Sleep();
      }

      CheckIfDead();
      Fullness = Fullness < 0 ? Fullness = 0 : Fullness;
      Attention = Attention < 0 ? Attention = 0 : Attention;
    }

    // Pet Actions
    public void Feed(int food) // WIP
    {
      if (IsFeeding == false)
      {
        IsFeeding = true;

        feedTimer = new Timer();
        feedTimer.Interval = 10000;
        feedTimer.Elapsed += FeedTimerElapsed;
        feedTimer.Start();

        Weight += 1;
        Fullness += food; // WIP
        Fullness = Fullness > 100 ? Fullness = 100 : Fullness;
      }
    }
  
    public void Sleep()
    {
      if (IsSleeping == false)
      {
        IsSleeping = true;

        sleepTimer = new Timer();
        sleepTimer.Interval = 10000;
        sleepTimer.Elapsed += SleepTimerElapsed;
        sleepTimer.Start();
      }
    }
    public void Play(int toy) // WIP
    {
      if (IsPlaying == false)
      {
        IsPlaying = true;

        playTimer = new Timer();
        playTimer.Interval = 10000;
        playTimer.Elapsed += PlayTimerElapsed;
        playTimer.Start();

        Attention += toy; // WIP
        Attention = Attention > 100 ? Attention = 100 : Attention;
      }
    }

    // Pet Management
    public static List<Pet> GetAll()
    {
      return _instances;
    }
    public static void ClearAll()
    {
      _instances.Clear();
    }
    public static void Delete(int petId)
    {
      var petToDelete = _instances.FirstOrDefault(p => p.Id == petId);
      if (petToDelete != null)
      {
        _instances.Remove(petToDelete);
      }
    }
    public static Pet Find(int searchId)
    {
      return _instances.FirstOrDefault(Pet => Pet.Id == searchId);
    }
  }
}