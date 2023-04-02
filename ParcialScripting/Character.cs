using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcialScripting
{
    public class Character
    {
        public string name;
        public int hp, attack, defense;
        private int type;
        public Weapon? weapon; //This means it can be null.
        public Shield? shield;
        public enum species { Human = 0, Beast = 1, Hybrid = 2 };

        public Character(string name, int hp, int attack, int defense, string type)
        {
            if (hp <= 0 || attack < 0 || defense < 0) throw new ArgumentException();
            this.name = name;
            this.hp = hp;
            this.attack = attack;
            this.defense = defense;
            weapon = null;
            shield = null;
            this.type = -1;
            if (type == "Human")
            {
                this.type = (int)Item.species.Human;
            }
            if (type == "Beast")
            {
                this.type = (int)Item.species.Beast;
            }
            if (type == "Hybrid")
            {
                this.type = (int)Item.species.Hybrid;
            }
            if (this.type == -1) throw new ArgumentException();
        }

        public Character(string name, int hp, int attack, int defense, string type, Weapon weapon, Shield shield)
        {
            if (hp <= 0 || attack < 0 || defense < 0) throw new ArgumentException();
            this.name = name;
            this.hp = hp;
            this.attack = attack;
            this.defense = defense;
            this.PickWeapon(weapon);
            this.PickShield(shield);
            this.type = -1;
            if (type == "Human")
            {
                this.type = (int)Item.species.Human;
            }
            if (type == "Beast")
            {
                this.type = (int)Item.species.Beast;
            }
            if (type == "Hybrid")
            {
                this.type = (int)Item.species.Hybrid;
            }
            if(this.type == -1) throw new ArgumentException();
        }

        public void PickWeapon(Weapon weapon)
        {
            if((this.type == weapon.type || weapon.type == 3)
                && weapon.getDurability() > 0 ) this.weapon = weapon;

        }

        public void PickShield(Shield shield)
        {
            if ((this.type == shield.type || shield.type == 3)
                && shield.getDurability() > 0) this.shield = shield;
        }

        public bool hasWeapon()
        {
            return weapon != null;
        }

        public bool hasShield()
        {
            return shield != null;
        }

        public void isDamaged()
        {
            if (this.hasWeapon())
            {
                if (this.weapon.getDurability() <= 0) this.weapon = null;
            }
            if (this.hasShield())
            {
                if (this.shield.getDurability() <= 0) this.shield = null;
            }
        }

        public void Attack(Character c)
        {
            if (this.hasWeapon())
            {
                weapon.durability--;

                if (c.hasShield()) 
                {
                    c.shield.durability -= this.weapon.power / 2;                    
                }
                else
                {
                    c.hp -= this.weapon.power;
                    if (c.hp < 0) c.hp = 0;
                }
            }
            else
            {
                if (c.hasShield())
                {
                    if (this.attack == 0) c.shield.durability--;
                    else c.shield.durability -= this.attack / 2;
                }
                else
                {
                    c.hp -= this.attack;
                    if (c.hp < 0) c.hp = 0;
                }
            }
            c.isDamaged();
            this.isDamaged();
        }
    }
}
