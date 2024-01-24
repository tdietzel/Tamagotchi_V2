using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tamagotchis.Models;

namespace Tamagotchis.Tests
{
  [TestClass]
  public class PetTests
  {
    [TestMethod]
    public void CheckConstructor_CheckIfConstructorCreatesInstance_Bool()
    {
      Pet newPet = new Pet();
      Assert.AreEqual(typeof(Pet), newPet.GetType());
    }

    [TestMethod]
    public void GetNameOfPet_ReturnsNameOfPet_String()
    {
      string name = "bob";
      Pet newPet = new Pet(name);
      string result = newPet.Name;
      Assert.AreEqual(name,result);
    }

    [TestMethod]
    public void SetNameOfPet_SetsNameOfPet_String()
    {
      string name = "bob";
      Pet newPet = new Pet(name);
      string result = newPet.Name;
      Assert.AreEqual(name,result);
    }
    [TestMethod]
    public void GetHungerOfPet_ReturnHungerOfPet_Int()
    {
      Pet newPet = new Pet();
      newPet.Hunger = 100;
      Assert.AreEqual(newPet.Hunger, 100);
    }
    [TestMethod]
    public void GetFatigueOfPet_ReturnFatigueOfPet_Int()
    {
      Pet newPet = new Pet();
      newPet.Fatigue = 100;
      Assert.AreEqual(newPet.Fatigue, 100);
    }
    [TestMethod]
    public void GetHappinessOfPet_ReturnHappinessOfPet_Int()
    {
      Pet newPet = new Pet();
      newPet.Happiness = 100;
      Assert.AreEqual(newPet.Happiness, 100);
    }
  }
}