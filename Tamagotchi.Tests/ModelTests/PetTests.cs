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
  }
}