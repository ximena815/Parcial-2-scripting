using ParcialScripting;

namespace TestProject1
{
    [TestClass]
    public class InstancesTests

    {

        [TestMethod]
        public void CharacterAndItemCreatedCorrectly()
        {
            Character c = new ParcialScripting.Character("Sam", 10, 10, 10, "Human");
            Assert.IsNotNull(c);
            Assert.AreEqual(10, c.hp);
            Assert.AreEqual(10, c.attack);
            Assert.AreEqual(10, c.defense);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]

        // If exception is thrown, means the objects cannot be instanced.
        // Items with negative atributes cannot be instanced.

        public void NonNegativeCharacterAttributes()
        {
            Character c = new ParcialScripting.Character("Sam", 10, -10, 10, "Human");
            Character d = new ParcialScripting.Character("Sam", -10, 10, 10, "Human");
            Character e = new ParcialScripting.Character("Sam", 10, 10, -10, "Human");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NonNegativeItemAttributes()
        {
            Weapon w = new Weapon("AK", -10, 10, "Human");
            Shield s = new Shield("Jacket", -10, 10, "Human");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NonNegativeOrZeroCharacterHP()
        {
            Character d = new ParcialScripting.Character("Sam", 0, 10, 10, "Human");
        }

        [TestMethod]
        public void WeaponAndShieldEquipedCorrectly()
        {
            Character d = new Character("Sam", 10, 10, 10, "Human");
            Character e = new Character("Leo", 10, 10, 10, "Beast");

            Weapon w = new Weapon("AK", 10, 10, "Human");
            Shield s = new Shield("Jacket", 10, 10, "Any");

            d.PickWeapon(w);
            d.PickShield(s);

            e.PickShield(s);

            Assert.IsTrue(d.weapon !=  null);
            Assert.IsTrue(d.shield != null);

            Assert.IsTrue(e.shield != null);
        }
        [TestMethod]
        public void WeaponAndShieldEquipedUncorrectly()
        {
            Character d = new Character("Sam", 10, 10, 10, "Human");
            Weapon w = new Weapon("AK", 10, 10, "Beast");
            Shield s = new Shield("Jacket", 10, 10, "Beast");

            d.PickWeapon(w);
            d.PickShield(s);

            Assert.IsTrue(d.weapon == null);
            Assert.IsTrue(d.shield == null);
        }

        [TestMethod]
        public void CharacterChangingWeaponOrShield()
        {
            Character d = new Character("Sam", 10, 10, 10, "Human");
            Weapon w = new Weapon("AK", 10, 10, "Human");
            Shield s = new Shield("Jacket", 10, 10, "Human");

            d.PickWeapon(w);
            d.PickShield(s);

            Assert.AreEqual(w, d.weapon);
            Assert.AreEqual(s, d.shield);

            Weapon x = new Weapon("M4", 20, 20, "Human");
            Shield t = new Shield("Vest", 20, 20, "Human");

            d.PickWeapon(x);
            d.PickShield(t);

            Assert.AreEqual(x, d.weapon);
            Assert.AreEqual(t, d.shield);
        }
    }
    
}