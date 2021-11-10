using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Major_Project_Final
{
    /// <summary>
    /// ASCIIGame starter code. 
    /// Welcome to the starter code for an ascii game!
    /// This starter code has some features but is missing others. It also isn't beautiful 
    /// 
    /// Features: 
    /// <point>Reads a text file</point>
    /// <point>Renders text file as map</point>
    /// <point>Detects if there is amonster and tells you which way</point>
    /// <point>Takes user input and moves the player in response</point>
    /// 
    /// Todo:
    /// <point>Collision Detection - Mobile Objects (players and monsters) can't walk through walls</point>
    /// <point>A combat system</point>
    /// <point>an inventory</point>
    /// <point>items that can change aspects of the combat system</point>
    /// <point>Classes</point>
    /// <point>Doors/chests that can open or close</point>
    /// <point>Mobs that can move to nearby opponents. (simple AI)</point>
    /// <point>Objects!</point>
    /// <point>Class Inheritance!</point>
    /// <point>Beautiful design patterns!</point>
    /// 
    /// Known bugs: 
    /// <point>Players and monsters aren't known on the map. So you don't know if you are standing on a mob/door/chest.</point>
    /// <point>If you go north or west you get an exception</point>
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // Enemies List
            List<Enemy> Enemies = new List<Enemy>();

            // Interactables Lists
            // Door Lists
            List<Door> Doors = new List<Door>();
            // Chest Lists
            List<Chest> Chests = new List<Chest>();

            // Potions
            Potions Potions = new Potions("Potions");
            Potions.Add(new HealingPotion("Healing Potion"));
            Potions.Add(new SpeedPotion("Speed Potion"));

            // Weapons
            Client client = new Client();
            IronSword IronSword = new IronSword();

            // Player
            Player Player = new Player(100, 3, 3, IronSword);

            // Enemies
            Enemy Enemy1 = new Enemy(50, 8, 3, Enemies, 20);

            //This path will read a map from your project directory
            var path = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, @"\\nas125e2.actedu.net.au\studenthome\born2004\09\0083844\my documents\visual studio 2015\Projects\Major Project\Major Project\Map.txt");
            string[] map = File.ReadAllLines(path);

            ConsoleKeyInfo user_input;
            Console.WriteLine("Press Q to quit");

            do
            {
                // Every time I start a loop, clear the screen. 
                Console.SetCursorPosition(0, 0);
                user_input = Console.ReadKey();

                for (int y = 0; y < map.Length; y++)
                {
                    for(int x = 0; x < map[y].Length; x++)
                    {

                    }
                }

                // Renders the map from the string[] map
                // I wonder if this should be in a function (or even better a Factory?)

                for (int y = 0; y < map.Length; y++)
                {
                    for (int x = 0; x < map[y].Length; x++)
                    {
                        // Render Doors
                        if (map[y][x] == '+')
                        {
                            Door d = new Door(new ClosedDoor(), x, y, Doors);
                            d.Draw();
                        }

                        // Render Chests
                        else if (map[y][x] == '~')
                        {
                            Chest c = new Chest(new ClosedChest(), x, y, Chests); 
                            c.Draw();
                        }

                        // Render Brutes
                        else if (x == Enemy1.mobX && y == Enemy1.mobY)
                        {
                            Enemy1.Draw();
                        }

                        // Render Player
                        else if (x == Player.playerX && y == Player.playerY)
                        {
                            Player.Draw();
                        }

                        // Render Rest of Map
                        else
                        {
                            Console.Write(map[y][x]);
                        }
                    }
                    Console.Write("\r\n");
                }
                Console.WriteLine("Press, up, down, left or right to move and Q to quit!");
                Console.WriteLine("Press 'E' to INTERACT with Chests and Doors and to ATTACK Enemies!");

                // Activating the AI method for Enemies
                foreach (Enemy e in Enemies)
                {
                    e.AI(Player, map);
                }

                // Capture user input
                
                if (user_input.Key == ConsoleKey.UpArrow)
                {
                    if (map[Player.playerY - 1][Player.playerX] != '#')
                    {
                        if (map[Player.playerY - 1][Player.playerX] != '+')
                        {
                            if (map[Player.playerY - 1][Player.playerX] != '~')
                            {
                                if (map[Player.playerY - 1][Player.playerX] != 'E')
                                {
                                    Player.playerY--;
                                }

                                else
                                {
                                    if (user_input.Key == ConsoleKey.E)
                                    {
                                        Player.Attack();
                                        Console.WriteLine(Enemy1.health);
                                        Enemy1.health -= Player.sword.damage;
                                        Console.WriteLine(Enemy1.health);
                                    }
                                }
                            }
                        }

                        else
                        {
                            if (user_input.Key == ConsoleKey.E)
                            {

                            }
                        }
                    }

                }
                else if (user_input.Key == ConsoleKey.DownArrow)
                {
                    if (map[Player.playerY + 1][Player.playerX] != '#')
                    {
                        if (map[Player.playerY + 1][Player.playerX] != '+')
                        {
                            if (map[Player.playerY + 1][Player.playerX] != '~')
                            {
                                if (map[Player.playerY + 1][Player.playerX] != 'E')
                                {
                                    Player.playerY++;
                                }
                            }
                        }

                        else
                        {
                        }
                    }
                }
                else if (user_input.Key == ConsoleKey.RightArrow)
                {
                    if (map[Player.playerY][Player.playerX + 1] != '#')
                    {
                        if (map[Player.playerY][Player.playerX + 1] != '+')
                        {
                            if (map[Player.playerY][Player.playerX + 1] != '~')
                            {
                                if (map[Player.playerY][Player.playerX + 1] != 'E')
                                {
                                    Player.playerX++;
                                }

                                else if (map[Player.playerY][Player.playerX + 1] == 'E')
                                {
                                    if (user_input.Key == ConsoleKey.E)
                                    {
                                        Enemy1.mobX -= 2;
                                        Player.Attack();
                                    }
                                }
                            }
                        }

                        else
                        {
                        }
                    }
                }
                else if (user_input.Key == ConsoleKey.LeftArrow)
                {
                    if (map[Player.playerY][Player.playerX - 1] != '#')
                    {
                        if (map[Player.playerY][Player.playerX - 1] != '+')
                        {
                            if (map[Player.playerY][Player.playerX - 1] != '~')
                            {
                                Player.playerX--;
                            }
                        }

                        else
                        {
                            Console.Write("\nPress 'E' to OPEN the Door!");
                        }
                    }
                }

            } while (user_input.Key != ConsoleKey.Q);
        }
    }
}
