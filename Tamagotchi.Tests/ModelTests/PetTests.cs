using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tamagotchis.Models;
using System.Threading;

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
    public void GetFullnessOfPet_ReturnFullnessOfPet_Int()
    {
      Pet newPet = new Pet();
      newPet.Fullness = 100;
      Assert.AreEqual(newPet.Fullness, 100);
    }
    [TestMethod]
    public void GetEnergyOfPet_ReturnEnergyOfPet_Int()
    {
      Pet newPet = new Pet();
      newPet.Energy = 100;
      Assert.AreEqual(newPet.Energy, 100);
    }
    [TestMethod]
    public void GetAttentionOfPet_ReturnAttentionOfPet_Int()
    {
      Pet newPet = new Pet();
      newPet.Attention = 100;
      Assert.AreEqual(newPet.Attention, 100);
    }
    [TestMethod]
    public void FeedPet_IncreaseFullness_Int()
    {
      Pet newPet = new Pet();
      int normalFood = 10;
      newPet.Fullness = 80;
      newPet.Feed(normalFood);
      int result = newPet.Fullness;
      Assert.AreEqual(result, 90);
    }
    [TestMethod]
    public void RestPet_IncreaseFullness_Int()
    {
      Pet newPet = new Pet();
      newPet.Energy = 80;
      newPet.Sleep();
      int result = newPet.Energy;
      Assert.AreEqual(result, 90);
    }
    [TestMethod]
    public void PlayPet_IncreaseAttention_Int()
    {
      Pet newPet = new Pet();
      newPet.Attention = 80;
      newPet.Play();
      int result = newPet.Attention;
      Assert.AreEqual(result, 90);
    }
    [TestMethod]
    public void CheckTimer_CheckIfTimerDecreasesAttributes_Int()
    {
      Pet newPet = new Pet();
      Thread.Sleep(13000);
      int result = newPet.Energy;
      Assert.AreEqual(98, result);
    }

    public void CheckIfDead_ReturnsDeadPet_Bool()
    {
      Pet newPet = new Pet();
      newPet.Fullness = 2;
      Thread.Sleep(13000);
      bool result = newPet.Alive;
      Assert.AreEqual(false, result);
    }
  }
}