using System;
using System.Timers;
using System.Collections.Generic;
using System.Windows;
using System.Linq;

namespace Tamagotchis.Models
{
  public class Pet
  {
    public string Name { get; private set; }
    public int Fullness { get; set; }
    public int Energy { get; set; }
    public int Attention { get; set; }
    public bool Alive { get; set; } = true;
    public int Id { get; }
    
    private Timer timer;

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
    public Pet()
    {
      Name = "Jim default";
      Fullness = 100;
      Energy = 100;
      Attention = 100;

      timer = new Timer();
      timer.Interval = 10000;
      timer.Elapsed += TimerElapsed;
      timer.Start();
      
      _instances.Add(this);
      Id = _instances.Count;
    }
    public Pet(string name)
    {
      Name = name;
      Fullness = 100;
      Energy = 100;
      Attention = 100;

      timer = new Timer();
      timer.Interval = 10000;
      timer.Elapsed += TimerElapsed;
      timer.Start();

      _instances.Add(this);
      Id = _instances.Count;
    }

    private void TimerElapsed(object sender, ElapsedEventArgs e)
    {
      DecreaseAttributes();
    }

    private void DecreaseAttributes()
    {
      Energy -= 2;
      Fullness -= 2;
      Attention -= 2;

      if (Energy < 0)
      {
        Energy = 0;
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
      if (Energy == 0 || Fullness == 0 || Attention == 0)
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
      Fullness += food;
      if (Fullness >= 100)
      {
        Fullness = 100;
      }
    }

    public void Sleep()
    {
      Energy += 10;
      if (Energy >= 100)
      {
        Energy = 100;
      }
    }
    
    public void Play()
    {
      Attention += 10;
      Fullness -= 2;
      Energy -= 2;
      if (Attention >= 100)
      {
        Attention = 100;
      }

      CheckIfDead();
    }

    public static Pet Find(int searchId)
    {
      return _instances[searchId - 1];
    }
  }
}