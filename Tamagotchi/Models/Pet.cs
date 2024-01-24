namespace Tamagotchis.Models
{
  public class Pet
  {
    public string Name { get; private set; }
    public int Fullness { get; set; }
    public int Energy { get; set; }
    public int Attention { get; set; }

    public Pet()
    {
      Name = "Jim default";
      Fullness = 100;
      Energy = 100;
      Attention = 100;
    }
    public Pet(string name)
    {
      Name = name;
      Fullness = 100;
      Energy = 100;
      Attention = 100;
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
      if (Attention >= 100)
      {
        Attention = 100;
      }
    }
  }
}