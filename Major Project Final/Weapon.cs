using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Major_Project_Final
{
    public abstract class Sword
    {
        public int damage;

        public abstract void Attack();
        public abstract string Detail();
    }

    public class IronSword : Sword
    {
        public override void Attack()
        {
            Console.WriteLine("YDADAD");
        }

        public override string Detail()
        {
            return "Iron Sword";
        }
    }

    public abstract class SwDecorator : Sword
    {
        private Sword sword;

        public SwDecorator(Sword _sword)
        {
            this.sword = _sword;
        }

        public void SetComponent(Sword _sword)
        {
            this.sword = _sword;
        }

        public override void Attack()
        {
            Console.WriteLine("Player attacks enemy: 3 Damage Given!");
        }

        public override string Detail()
        {
            if (this.sword != null)
            {
                return this.sword.Detail();
            }
            else
            {
                return string.Empty;
            }
        }
    }

    public class FireSwordDecorator : SwDecorator
    {
        public FireSwordDecorator(Sword _sword) : base(_sword)
        {

        }

        public override void Attack()
        {
            Console.WriteLine("Player attacks enemy: 3 Damage Given + 2 Fire Damage Given!");
        }

        public override string Detail()
        {
            return "Fire(Iron Sword)";
        }
    }

    public class Client
    {
        public void ClientCode(Sword _sword)
        {
            Console.WriteLine("RESULT: " + _sword.Detail());
        }
    }
}
