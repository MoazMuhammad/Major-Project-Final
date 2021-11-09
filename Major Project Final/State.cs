using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Major_Project_Final
{
    public abstract class State
    {
        public Door door;
        public Enemy enemy;
        public Chest chest;

        public void SetDoor(Door _door)
        {
            this.door = _door;
        }

        public void SetEnemy(Enemy _enemy)
        {
            this.enemy = _enemy;
        }

        public void SetChest(Chest _chest)
        {
            this.chest = _chest;
        }

        public abstract void NextState();
        public abstract void StateAction();
        public abstract void Draw();
    }
}
