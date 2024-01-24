namespace Tamagotchis.Models
{
  public class Pet
  {
    public string Name { get; private set; }
    public int Fullness { get; set; }
    public int Fatigue { get; set; }
    public int Happiness { get; set; }

    public Pet()
    {
      Name = "Jim default";
      Fullness = 100;
      Fatigue = 100;
      Happiness = 100;
    }
    public Pet(string name)
    {
      Name = name;
      Fullness = 100;
      Fatigue = 100;
      Happiness = 100;
    }
    
    public void Feed(int food)
    {
      Fullness += food;
      if (Fullness >= 100)
      {
        Fullness = 100;
      }
    }
    // public void Sleep()
    // {
    //   Fatigue += 10;
    //   if (Fatigue >= 100)
    //   {
    //     Fatigue = 100;
    //   }
    // }
    // public void Play()
    // {
    //   Happiness += 10;
    //   if (Happiness >= 100)
    //   {
    //     Happiness = 100;
    //   }
    // }
  }
}