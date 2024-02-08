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
      public List<Food> FoodList { get; set; }
      public List<Toy> ToyList { get; set; }
    }

    // Pet Variables
    public User User { get; set; }
    public int UserId { get; set; }

    public string Name { get; set; }

    public bool Alive { get; set; } = true;
    public int Age { get; set; }
    public string Type { get; set; }
    public int PetId { get; set; }

    public int Fullness { get; set; }
    public int Energy { get; set; }
    public int Attention { get; set; }
    public int Weight { get; set; } = 1;


    // Timers
    private Timer ageTimer;
    private Timer statTicker;

    // Pet Actions
    public bool IsHatched { get; set; } = false;
    public bool IsFeeding { get; set; } = false;
    public bool IsSleeping { get; set; } = false;
    public bool IsPlaying { get; set; } = false;


    // Pet Constructors
    private static List<Pet> _instances = new List<Pet> { };

    public Pet()
    {
      Fullness = 100;
      Energy = 0;
      Attention = 100;

      InitializeTimers();
      _instances.Add(this);
    }

    public static List<Pet> GetAll()
    {
      return _instances;
    }

    // Timers
    public void InitializeTimers()
    {
      ageTimer = new Timer();
      ageTimer.Interval = 6000; // 86400000; // 24 hours in milliseconds
      ageTimer.Elapsed += AgeTimerElapsed;
      ageTimer.Start();

      statTicker = new Timer();
      statTicker.Interval = 10000;
      statTicker.Elapsed += StatTickerElapsed;
      statTicker.Start();
    }

    private void AgeTimerElapsed(object sender, ElapsedEventArgs e)
    {
      Age += 1;
    }

    private void StatTickerElapsed(object sender, ElapsedEventArgs e)
    {
      DecreaseAttributes();
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

        Fullness += 20;
        Fullness = Fullness > 100 ? Fullness = 100 : Fullness;

        Weight += 1;
        Fullness += food; // WIP
        Fullness = Fullness > 100 ? Fullness = 100 : Fullness;
      }
      else
      {
        IsFeeding = false;
      }
    }
    public void Sleep()
    {
      if (IsSleeping == false)
      {
        IsSleeping = true;
        Energy = 100;
      }
      else
      {
        IsSleeping = false;
      }
    }
    public void Play(int toy) // WIP
    {
      if (IsPlaying == false)
      {
        IsPlaying = true;

        if (Energy < 5)
        {
          Energy = 0;
        }
        else
        {
          Fullness -= 5;
          Energy -= 20;
        }
        // Attention += toy; // WIP
        Attention = Attention > 100 ? Attention = 100 : Attention;
      }
      else
      {
        IsPlaying = false;
      }
    }
  }
}