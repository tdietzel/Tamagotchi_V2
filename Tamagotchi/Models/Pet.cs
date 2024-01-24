namespace Tamagotchis.Models
{
  public class Pet
  {
    public string Name { get; private set; }
    public int Hunger { get; set; }
    public int Fatigue { get; set; }
    public int Happiness { get; set; }

    public Pet()
    {
      Name = "Jim default";
      Hunger = 100;
      Fatigue = 100;
      Happiness = 100;
    }
    public Pet(string name)
    {
      Name = name;
      Hunger = 100;
      Fatigue = 100;
      Happiness = 100;
    }
  }
}