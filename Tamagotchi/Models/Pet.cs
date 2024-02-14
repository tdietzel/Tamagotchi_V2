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
  public class Pet
  {
    // Database
    private readonly TamagotchiContext _db;
    public Pet(TamagotchiContext db)
    {
      _db = db;
    }

    [Key]
    public int PetId { get; set; }

    [ForeignKey("User")]
    public string Id { get; set; }
    public User User { get; set; }

    // Pet Variables
    public string Name { get; set; }

    public bool Alive { get; set; } = true;
    public int Age { get; set; }
    public string Type { get; set; }

    public int Fullness { get; set; }
    public int Energy { get; set; }
    public int Attention { get; set; }
    public int Weight { get; set; } = 1;

    // Timers
    private Timer ageTimer;
    private Timer statTicker;
    public DateTime UpdatedDate { get; set; }
    public DateTime CreationDate { get; set; }

    // Pet Constructor
    public Pet()
    {
      Fullness = 100;
      Energy = 0;
      Attention = 100;
      CreationDate = DateTime.Now;
      UpdatedDate = DateTime.Now;
      InitializeTimers();
    }

    // Pet Actions
    public bool IsHatched { get; set; } = false;
    public bool IsFeeding { get; set; } = false;
    public bool IsSleeping { get; set; } = false;
    public bool IsPlaying { get; set; } = false;

    // Timers
    public void InitializeTimers()
    {
      ageTimer = new Timer();
      ageTimer.Interval = 6000; // 86400000; // 24 hours in milliseconds
      ageTimer.Elapsed += AgeTimerElapsed;
      ageTimer.Start();

      statTicker = new Timer();
      statTicker.Interval = 1000;
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
      Pet petToUpdate = _db.Pets.Find(this.PetId);
      if (petToUpdate != null)
      {
        petToUpdate.Fullness = this.Fullness;
        petToUpdate.Energy = this.Energy;
        petToUpdate.Attention = this.Attention;
        _db.SaveChanges();
      }
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
    public void DecreaseAttributes()
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