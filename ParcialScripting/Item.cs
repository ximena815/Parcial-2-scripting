using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcialScripting
{
    public abstract class Item
    {
        internal string name;
        internal int power, type;
        internal int durability;

        public enum species {Human = 0, Beast = 1, Hybrid = 2, Any = 3 };

        public Item(string name, int power, int durability, string species)
        {
            this.name = name;
            this.power = power;
            this.durability = durability;

            if (power <0 || durability <= 0) throw new ArgumentException();

            if (species == "Human")
            {
                type = (int)Item.species.Human;
            }
            if (species == "Beast")
            {
                type = (int)Item.species.Beast;
            }
            if (species == "Hybrid")
            {
                type = (int)Item.species.Hybrid;
            }
            if (species == "Any")
            {
                type = (int)Item.species.Any;
            }
        }
        public int getDurability()
        {
            return this.durability;
        }
    }
}
