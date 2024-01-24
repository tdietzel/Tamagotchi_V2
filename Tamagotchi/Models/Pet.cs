namespace Tamagotchis.Models
{
  public class Pet
  {
    public string Name { get; }
    // public string Name { get; set; }
    // public int Hunger { get; set; }
    // public int Fatigue { get; set; }
    // public int Happiness { get; set; }
    public Pet(string name)
    {
      Name = name;
    }
  }
}