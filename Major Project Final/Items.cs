using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Major_Project_Final
{
    // Component
    public abstract class Items
    {
        public string name;

        public Items(string _name)
        {
            this.name = _name;
        }

        public abstract void Add(Items x);
        public abstract void Remove(Items x);
        public abstract void Display(int indent);


    }

    // Composite for Potions
    public class Potions : Items
    {
        List<Items> potions = new List<Items>();

        public Potions(string name) : base(name)
        {

        }

        public override void Add(Items x)
        {
            potions.Add(x);
        }

        public override void Remove(Items x)
        {
            potions.Remove(x);
        }

        public override void Display(int indent)
        {
            Console.WriteLine(new String('-', indent) + name);

            foreach (Items x in potions)
            {
                x.Display(indent + 2);
            }
        }
    }

    // Leaf for Potions composite
    public class HealingPotion : Items
    {
        public HealingPotion(string name) : base(name)
        {
        }

        public override void Add(Items x)
        {
            Console.WriteLine("Cannot add Healing Potion to Healing Potion!");
        }

        public override void Remove(Items x)
        {
            Console.WriteLine("Cannot remove Healing Potion from Healing Potion!");
        }

        public override void Display(int indent)
        {
            Console.WriteLine(new String('-', indent) + name);
        }
    }

    // Another Leaf for Potions composite
    public class SpeedPotion : Items
    {
        public SpeedPotion(string name) : base(name)
        {
        }

        public override void Add(Items x)
        {
            Console.WriteLine("Cannot add Speed Potion to Speed Potion!");
        }

        public override void Remove(Items x)
        {
            Console.WriteLine("Cannot remove Speed Potion from Speed Potion!");
        }

        public override void Display(int indent)
        {
            Console.WriteLine(new String('-', indent) + name);
        }
    }
}
