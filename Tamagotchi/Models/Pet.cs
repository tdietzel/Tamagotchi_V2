using System;
using System.Timers;
using System.Collections.Generic;
using System.Windows;
using System.Linq;

namespace Tamagotchis.Models
{
  public class Pet
  {
    public static List<Food> _inventory = Food.GetAll();
    public static List<Toy> _inventoryToy = Toy.GetAll();

     public class FoodAndToyModel
  {
    public List<Food> FoodList {get; set;}
    public List<Toy> ToyList {get; set;}
  }
    public string Name { get; private set; }
    public string Type { get; set; }
    public int Fullness { get; set; }
    public int Energy { get; set; }
    public int Attention { get; set; }
    public int Age { get; set; }
    public int Weight { get; set; } = 1;
    public bool Alive { get; set; } = true;
    public int Id { get; }
    private static int nextId = 1;

    private Timer incubationTimer;
    private Timer ageTimer;
    private Timer timer;
    private Timer sleepTimer;
    private Timer playTimer;
    private Timer feedTimer;

    public bool IsSleeping { get; set; } = false;
    public bool IsHatched { get; set; } = false;
    public bool IsPlaying { get; set; } = false;
    public bool IsFeeding { get; set; } = false;

    private static List<Pet> _instances = new List<Pet> { };

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

    public Pet()
    {
      Name = "Jim default";
      Type = "";
      Fullness = 100;
      Energy = 0;
      Attention = 100;

      timer = new Timer();
      timer.Interval = 10000;
      timer.Elapsed += TimerElapsed;
      timer.Start();

      _instances.Add(this);
      Id = _instances.Count;

      incubationTimer = new Timer();
      incubationTimer.Interval = 10000;
      incubationTimer.Elapsed += HatchTimerElapsed;
      incubationTimer.Start();

      ageTimer = new Timer();
      ageTimer.Interval = 600000; // 86400000; // 24 hours in milliseconds
      ageTimer.Elapsed += AgeTimerElapsed;
      ageTimer.Start();
    }

    public Pet(string name)
    {
      Name = name;
      Fullness = 100;
      Energy = 0;
      Attention = 100;

      timer = new Timer();
      timer.Interval = 10000;
      timer.Elapsed += TimerElapsed;
      timer.Start();

      _instances.Add(this);
      Id = nextId;
      nextId++;

      incubationTimer = new Timer();
      incubationTimer.Interval = 10000;
      incubationTimer.Elapsed += HatchTimerElapsed;
      incubationTimer.Start();

      ageTimer = new Timer();
      ageTimer.Interval = 600000;//10mins | 86400000; 24 hours in milliseconds
      ageTimer.Elapsed += AgeTimerElapsed;
      ageTimer.Start();
    }

    private void HatchTimerElapsed(object sender, ElapsedEventArgs e)
    {
      IsHatched = true;
      Energy = 100;
      Random randomEgg = new Random();
      int randomResult = randomEgg.Next(1, 3);
      if (randomResult == 1)
      {
        Type = "Dog";
      }
      else
      {
        Type = "Cat";
      }
      ((Timer)sender).Stop();
    }

    private void AgeTimerElapsed(object sender, ElapsedEventArgs e)
    {
      Age += 1;
    }

    private void SleepTimerElapsed(object sender, ElapsedEventArgs e)
    {
      IsSleeping = false;
      Energy = 100;
      ((Timer)sender).Stop();
    }
    private void FeedTimerElapsed(object sender, ElapsedEventArgs e)
    {
      CheckIfDead();
      IsFeeding = false;
      Fullness += 20;
      if (Fullness > 100)
      {
        Fullness = 100;
      }
      ((Timer)sender).Stop();
    }

    private void TimerElapsed(object sender, ElapsedEventArgs e)
    {
      DecreaseAttributes();
    }

    private void PlayTimerElapsed(object sender, ElapsedEventArgs e)
    {
      CheckIfDead();
      IsPlaying = false;
      if (Fullness < 5)
      {
        Fullness = 0;
      }
      if (Energy < 5)
      {
        Energy = 0;
      }
      else
      {
        Fullness -= 5;
        Energy -= 20;
        if (Attention < 50)
        {
          Attention += 50;
        }
        else 
        {
          Attention = 100;
        }
      }
      ((Timer)sender).Stop();
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
      if (Fullness < 0)
      {
        Fullness = 0;
      }
      if (Attention < 0)
      {
        Attention = 0;
      }

      CheckIfDead();
    }

    private void CheckIfDead()
    {
      if (Fullness == 0)
      {
        Energy = 0;
        Fullness = 0;
        Attention = 0;
        timer.Stop();
        Alive = false;
      }
    }

    public void Feed(int food)
    {
      if (IsFeeding == false)
      {
        IsFeeding = true;
        feedTimer = new Timer();
        feedTimer.Interval = 10000;
        feedTimer.Elapsed += FeedTimerElapsed;
        Fullness += food;
        Weight += 1;
        if (Fullness > 100)
        {
          Fullness = 100;
        }
        feedTimer.Start();
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

    public void Play(int toy)
    {
      if (IsPlaying == false)
      {
        IsPlaying = true;
        playTimer = new Timer();
        playTimer.Interval = 10000;
        playTimer.Elapsed += PlayTimerElapsed;
        Attention += toy;
        if (Attention > 100)
        {
          Attention = 100;
        }
        playTimer.Start();
      }
    }
  }
}

// goes to the bathroom & add a clean up option
// treat for happiness food for fullness
// 1 year = 1 day
// amount of times fed = 1 pound each time
// goes to bed at night and you need to turn the light off to raise attention