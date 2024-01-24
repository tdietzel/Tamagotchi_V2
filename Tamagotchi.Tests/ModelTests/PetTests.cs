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
      Pet newPet = new Pet("bob");
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
  }
}