using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Major_Project_Final
{
    public class Player
    {
        public int health;
        public int playerX;
        public int playerY;
        public char tile;
        public Sword sword;
        public List<Door> doors;

        public Player(int _health, int _playerX, int _playerY, Sword _sword)
        {
            this.health = _health;
            this.playerX = _playerX;
            this.playerY = _playerY;
            this.sword = _sword;
        }

        public void Draw()
        {
            Console.Write("@");
        }

        public void getTile(string[] _map)
        {
            tile = _map[this.playerY][this.playerX];
            Console.WriteLine("You are standing on " + tile);
        }

        public void Attack()
        {
            Console.WriteLine("CLIENT: Player attacked Enemy dealing " + this.sword.damage + "damage!");
        }

        public void Movement(ConsoleKeyInfo _user_input, string[] _map, List<Door> _doors)
        {
            this.doors = _doors;

            if (_user_input.Key == ConsoleKey.UpArrow)
            {
                if (_map[this.playerY - 1][this.playerX] != '#')
                {
                    if (_map[this.playerY - 1][this.playerX] == '+')
                    {
                        Console.WriteLine("CLIENT: Press 'E' to OPEN the Door!'");
                        //_door.TransitionTo(new OpenDoor());
                    }

                    else
                    {
                        this.playerY--;
                    }
                }
            }
            else if (_user_input.Key == ConsoleKey.DownArrow)
            {
                if (_map[this.playerY + 1][this.playerX] != '#')
                {
                    if (_map[this.playerY + 1][this.playerX] == '+')
                    {
                        Console.WriteLine("CLIENT: Press 'E' to OPEN the Door!'");
                        //_door.TransitionTo(new OpenDoor());
                    }

                    else
                    {
                        this.playerY++;
                    }
                }
            }
            else if (_user_input.Key == ConsoleKey.RightArrow)
            {
                if (_map[this.playerY][this.playerX + 1] != '#')
                {
                    if (_map[this.playerY][this.playerX + 1] == '+')
                    {
                        Console.WriteLine("CLIENT: Press 'E' to OPEN the Door!'");
                        //_door.TransitionTo(new OpenDoor());
                    }

                    else
                    {
                        this.playerX++;
                    }
                }
            }
            else if (_user_input.Key == ConsoleKey.LeftArrow)
            {
                if (_map[this.playerY][this.playerX - 1] != '#')
                {
                    if (_map[this.playerY][this.playerX - 1] == '+')
                    {
                        Console.WriteLine("CLIENT: Press 'E' to OPEN the Door!'");
                        //_door.TransitionTo(new OpenDoor());
                    }

                    else
                    {
                        this.playerX--;
                    }
                }
            }
        }
    }
}
