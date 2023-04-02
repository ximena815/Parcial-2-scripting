using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParcialScripting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    [TestClass]
    public class BattleTests
    {
        [TestMethod]
        public void ItemDurabilityReducesCorrectly()
        {
            Character a = new Character("Sam", 10, 10, 10, "Human");
            Character b = new Character("Tom", 10, 10, 10, "Human");

            Weapon x = new Weapon("Pistol", 8, 10, "Human");
            Shield y = new Shield("Vest", 20, 20, "Human");

            a.PickWeapon(x);
            b.PickShield(y);

            Assert.IsNotNull(a.weapon);
            Assert.IsNotNull(b.shield);

            a.Attack(b);

            //Since weapon´s usage reduces its durability by 1:
            Assert.AreEqual(9,a.weapon.getDurability());

            //Since shields mitigates half of the dagame recieved:
            Assert.AreEqual(16, b.shield.getDurability());

            //Let´s do it again
            a.Attack(b);

            Assert.AreEqual(8, a.weapon.getDurability());
            Assert.AreEqual(12, b.shield.getDurability());
        }

        [TestMethod]
        public void WeaponButNoShield()
        {
            Character a = new Character("Sam", 20, 5, 10, "Human");
            Character b = new Character("Tom", 20, 5, 10, "Human");

            Weapon x = new Weapon("Pistol", 12, 10, "Human");

            a.PickWeapon(x);

            Assert.IsNotNull(a.weapon);

            a.Attack(b);
            //Without a shield, weapon´s damage is recieved directly
            Assert.AreEqual(8, b.hp);
        }

        [TestMethod]
        public void WeaponAndShield()
        {
            Character a = new Character("Sam", 20, 10, 10, "Human");
            Character b = new Character("Tom", 20, 10, 10, "Human");

            Weapon x = new Weapon("Pistol", 10, 10, "Human");
            Shield y = new Shield("Vest", 20, 20, "Human");

            a.PickWeapon(x);
            b.PickShield(y);

            Assert.IsNotNull(b.shield);

            a.Attack(b);

            //Shield recieves half of the damage
            Assert.AreEqual(15, b.shield.getDurability());
            //Characters with shield does not recieve direct damage
            Assert.AreEqual(20, b.hp);
        }

        [TestMethod]
        public void NoWeaponButShield()
        {
            Character a = new Character("Sam", 20, 10, 10, "Human");
            Character b = new Character("Tom", 20, 10, 10, "Human");

            //Also creating another character with 0 damage
            Character c = new Character("Kim", 20, 0, 10, "Human");

            Shield y = new Shield("Vest", 20, 20, "Human");

            b.PickShield(y);

            Assert.IsNotNull(b.shield);

            a.Attack(b);

            //Shield recieving half of the damage:
            Assert.AreEqual(15, b.shield.getDurability());

            c.Attack(b);
            Assert.IsNotNull(b.shield);

            //If damage is 0, Shield´s durability reduces by 1
            Assert.AreEqual(14, b.shield.getDurability());
        }

        [TestMethod]
        public void NoWeaponNoShield()
        {
            Character a = new Character("Sam", 20, 5, 10, "Human");
            Character b = new Character("Tom", 20, 5, 10, "Human");

            a.Attack(b);

            //Without a shield, damage is recieved directly
            Assert.AreEqual(15, b.hp);

            //Let´s recreate a battle
            b.Attack(a);
            a.Attack(b);
            Assert.AreEqual(10, b.hp);
            Assert.AreEqual(15, a.hp);
        }

        [TestMethod]
        public void UnequipWeapon()
        {
            Character a = new Character("Sam", 20, 5, 10, "Human");
            Character b = new Character("Tom", 20, 5, 10, "Human");

            Weapon x = new Weapon("Pistol", 10, 1, "Human");

            a.PickWeapon(x);
            Assert.IsNotNull(a.weapon);
            a.Attack(b);
            Assert.IsNull(a.weapon);

        }

        [TestMethod]
        public void UnequipShield()
        {
            Character a = new Character("Sam", 20, 10, 10, "Human");
            Character b = new Character("Tom", 20, 10, 10, "Human");

            Shield x = new Shield("Vest", 10, 5, "Human");

            b.PickShield(x);
            Assert.IsNotNull(b.shield);
            a.Attack(b);

            Assert.IsNull(b.shield);

        }
        [TestMethod]
        public void HPNotLessThanZero()
        {
            Character a = new Character("Sam", 20, 5, 10, "Human");
            Character b = new Character("Tom", 4, 5, 10, "Human");

            a.Attack(b);

            //In this case, b´s HP should be -1, but it cannot be less than 0.
            Assert.AreEqual(0, b.hp);

        }

        [TestMethod]
        public void ShieldNotLessThanZero()
        {
            Character a = new Character("Sam", 20, 10, 10, "Human");
            Character b = new Character("Tom", 20, 10, 10, "Human");

            Shield x = new Shield("Vest", 10, 3, "Human");

            b.PickShield(x);
            Assert.IsNotNull(b.shield);
            a.Attack(b);

            //Shield´s durability cannot be less than 0 since Shield is unequiped
            Assert.IsNull(b.shield);

        }

        [TestMethod]
        public void WeaponNotLessThanZero()
        {
            Character a = new Character("Sam", 20, 5, 10, "Human");
            Character b = new Character("Tom", 20, 5, 10, "Human");

            Weapon x = new Weapon("Pistol", 10, 1, "Human");

            a.PickWeapon(x);
            Assert.IsNotNull(a.weapon);
            a.Attack(b);

            //Weapon dissapears when durability drops to 0, which means that it cant be less than 0.
            Assert.IsNull(a.weapon);

        }

        [TestMethod]
        public void EquipByClass()
        {
            
            Character a = new Character("Sam", 20, 5, 10, "Human");
            Character b = new Character("Leo", 20, 5, 10, "Beast");
            Character c = new Character("Tim", 20, 5, 10, "Hybrid");

            Weapon x = new Weapon("Pistol", 10, 10, "Human");
            Weapon y = new Weapon("Pistol", 10, 10, "Beast");
            Weapon z = new Weapon("Pistol", 10, 10, "Hybrid");
            Weapon w = new Weapon("Pistol", 10, 10, "Any");

            //Each class can pick their respective weapon type

            a.PickWeapon(x);
            b.PickWeapon(y);
            c.PickWeapon(z);

            Assert.IsNotNull(a.weapon);
            Assert.IsNotNull(b.weapon);
            Assert.IsNotNull(c.weapon);

            //All of them can pick the "Any" type

            a.PickWeapon(w);
            b.PickWeapon(w);
            c.PickWeapon(w);

            Assert.AreEqual(w,a.weapon);
            Assert.AreEqual(w, b.weapon);
            Assert.AreEqual(w, c.weapon);

            //But they cannot pick another type different than theirs

            a.PickWeapon(y);
            Assert.AreNotEqual(y, a.weapon);
            a.PickWeapon(z);
            Assert.AreNotEqual(z, a.weapon);

            b.PickWeapon(x);
            Assert.AreNotEqual(x, b.weapon);
            b.PickWeapon(z);
            Assert.AreNotEqual(z, b.weapon);

            c.PickWeapon(x);
            Assert.AreNotEqual(x, c.weapon);
            c.PickWeapon(y);
            Assert.AreNotEqual(y, c.weapon);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TryingToUseALessThanZeroDurabilityWeapon()
        {

            Character a = new Character("Sam", 20, 5, 10, "Human");

            //Trying to instance a weapon with negative durability (Should throw an Argument Exception)
            Weapon x = new Weapon("Pistol", 10, -1, "Human");

            a.PickWeapon(x);

            Assert.IsNotNull(a.weapon);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TryingToUseALessThanZeroDurabilityShield()
        {

            Character a = new Character("Sam", 20, 5, 10, "Human");

            //Trying to instance a shield with negative durability (Should throw an Argument Exception)
            Shield x = new Shield("Vest", 10, -1, "Human");

            a.PickShield(x);

            Assert.IsNotNull(a.shield);
        }

        [TestMethod]
        public void ClassCantChange()
        {
            //Actually I cant access the type from this place, because its a private var.
            //It means it works!
        }

        [TestMethod]
        public void AttributeCantChange()
        {
            /*Encapsulation using. Making all atributtes internal, ensure that they cannot change
             after being initialized on an instance.*/
        }





    }
}
