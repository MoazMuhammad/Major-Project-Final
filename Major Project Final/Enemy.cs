using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Major_Project_Final
{
    public class Enemy
    {
        public State state = null;
        public int health;
        public int mobX, mobY;
        public Player player;
        public string[] map;
        public int damage;
        public List<Enemy> enemies;

        public Enemy(int _health, int _mobX, int _mobY, List<Enemy> _enemies, int _damage)
        {
            this.health = _health;
            this.mobX = _mobX;
            this.mobY = _mobY;
            this.enemies = _enemies;
            this.damage = _damage;

            enemies.Add(this);
        }

        public void TransitionTo(State _state)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("[UPDATE] Enemy State: " + _state.GetType().Name);
            this.state = _state;
            this.state.SetEnemy(this);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void Request1()
        {
            this.state.NextState();
        }

        public void Request2()
        {
            this.state.StateAction();
        }

        public void Draw()
        {
            Console.Write("E");
        }

        // A simple AI for the Enemy which follows the player.
        public void AI(Player _player, string[] _map)
        {
            this.player = _player;

            int deltaX = player.playerX - this.mobX;
            int deltaY = player.playerY - this.mobY;

            Console.Write("There is a noise from the");

            if (deltaY > 0)
            {
                Console.Write(" North");
                if (_map[this.mobY - 1][this.mobX] != '#')
                {
                    if (_map[this.mobY - 1][this.mobX] != _map[_player.playerY][_player.playerX])
                    {
                        this.mobY++;
                    }

                    else
                    {
                        Console.WriteLine("Press 'E' to ATTACK the Enemy!");
                        this.Attack();
                    }
                }
            }
            else if (deltaY < 0)
            {
                Console.Write(" South");
                if (_map[this.mobY + 1][this.mobX] != '#')
                {
                    if (_map[this.mobY + 1][this.mobX] != _map[_player.playerY][_player.playerX])
                    {
                        this.mobY++;
                    }

                    else
                    {
                        Console.WriteLine("Press 'E' to ATTACK the Enemy!");
                        this.Attack();
                    }
                }
            }

            if (deltaX > 0)
            {
                Console.Write(" West");
                if (_map[this.mobY][this.mobX + 1] != '#')
                {
                    if (_map[this.mobY][this.mobX + 1] != '@')
                    {
                        this.mobX++;
                    }

                    else
                    {
                        Console.WriteLine("Press 'E' to ATTACK the Enemy!");
                        this.Attack();
                    }
                }
            }
            else if (deltaX < 0)
            {
                Console.Write(" East");
                if (_map[this.mobY][this.mobX - 1] != '#')
                {
                    if (_map[this.mobY][this.mobX - 1] != '@')
                    {
                        this.mobX--;
                    }

                    else
                    {
                        Console.WriteLine("Press 'E' to ATTACK the Enemy!");
                        this.Attack();
                    }
                }
            }
            Console.Write(". ");
        }

        // Attack method for Enemy
        public void Attack()
        {
            Console.WriteLine("CLIENT: Player attacked Enemy dealing " + this.damage + "damage!");
        }
    }
    
}
