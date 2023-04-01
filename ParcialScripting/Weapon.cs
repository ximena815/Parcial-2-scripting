using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcialScripting
{
    public class Weapon : Item
    {
        public Weapon(string name, int power, int durability, string species)
            : base(name, power, durability, species) {

        }
    }
}
