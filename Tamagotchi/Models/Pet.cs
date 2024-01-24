using System;
using System.Timers;

namespace Tamagotchis.Models
{
  public class Pet
  {
    public string Name { get; private set; }
    public int Fullness { get; set; }
    public int Energy { get; set; }
    public int Attention { get; set; }
    public bool Alive { get; set; } = true;
    
    private Timer timer;

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
  }
}