using ParcialScripting;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NonNegativeAttributes()
        {
            Character c = new ParcialScripting.Character("Sam", 10, -10, 10, "Human");
            Character d = new ParcialScripting.Character("Sam", -10, 10, 10, "Human");
            Character e = new ParcialScripting.Character("Sam", 10, 10, -10, "Human");
        }
    }
}