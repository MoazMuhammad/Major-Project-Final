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

            // Interactables
            // Doors
            Door Door1 = new Door(new ClosedDoor(), 9, 2, Doors);
            Door Door2 = new Door(new ClosedDoor(), 3, 5, Doors);
            Door Door3 = new Door(new ClosedDoor(), 19, 4, Doors);
            Door Door4 = new Door(new ClosedDoor(), 49, 7, Doors);
            Door Door5 = new Door(new ClosedDoor(), 56, 11, Doors);
            Door Door6 = new Door(new ClosedDoor(), 16, 13, Doors);
            Door Door7 = new Door(new ClosedDoor(), 32, 17, Doors);
            Door Door8 = new Door(new ClosedDoor(), 43, 24, Doors);
            Door Door9 = new Door(new ClosedDoor(), 22, 32, Doors);
            
            // Chests
            Chest Chest1 = new Chest(new ClosedChest(), 1, 1, Chests);
            Chest Chest2 = new Chest(new ClosedChest(), 1, 14, Chests);
            Chest Chest3 = new Chest(new ClosedChest(), 28, 9, Chests);
            Chest Chest4 = new Chest(new ClosedChest(), 56, 14, Chests);
            Chest Chest5 = new Chest(new ClosedChest(), 1, 25, Chests);
            Chest Chest6 = new Chest(new ClosedChest(), 1, 32, Chests);

            // I need to know what kind of tile I am standing on. 
            char tile;

            //This path will read a map from your project directory
            var path = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, @"C:\Users\PC\OneDrive\Desktop\Canberra College\Programming\Assignments\Major Project Final\Major Project Final\map.txt");
            string[] map = File.ReadAllLines(path);

            ConsoleKeyInfo user_input;
            Console.WriteLine("Press Q to quit");

            do
            {
                // Every time I start a loop, clear the screen. 
                Console.SetCursorPosition(0, 0);

                // Renders the map from the string[] map
                // I wonder if this should be in a function (or even better a Factory?)

                for (int y = 0; y < map.Length; y++)
                {
                    for (int x = 0; x < map[y].Length; x++)
                    {
                        // Render Doors
                        if (x == Door1.doorX && y == Door1.doorY)
                        {
                            Door1.Draw();
                        }
                        else if (x == Door2.doorX && y == Door2.doorY)
                        {
                            Door2.Draw();
                        }
                        else if (x == Door3.doorX && y == Door3.doorY)
                        {
                            Door3.Draw();
                        }
                        else if (x == Door4.doorX && y == Door4.doorY)
                        {
                            Door4.Draw();
                        }
                        else if (x == Door5.doorX && y == Door5.doorY)
                        {
                            Door5.Draw();
                        }
                        else if (x == Door6.doorX && y == Door6.doorY)
                        {
                            Door6.Draw();
                        }
                        else if (x == Door7.doorX && y == Door7.doorY)
                        {
                            Door7.Draw();
                        }
                        else if (x == Door8.doorX && y == Door8.doorY)
                        {
                            Door8.Draw();
                        }
                        else if (x == Door9.doorX && y == Door9.doorY)
                        {
                            Door9.Draw();
                        }

                        // Render Chests
                        else if (x == Chest1.chestX && y == Chest1.chestY)
                        {
                            Chest1.Draw();
                        }
                        else if (x == Chest2.chestX && y == Chest2.chestY)
                        {
                            Chest2.Draw();
                        }
                        else if (x == Chest3.chestX && y == Chest3.chestY)
                        {
                            Chest3.Draw();
                        }
                        else if (x == Chest4.chestX && y == Chest4.chestY)
                        {
                            Chest4.Draw();
                        }
                        else if (x == Chest5.chestX && y == Chest5.chestY)
                        {
                            Chest5.Draw();
                        }
                        else if (x == Chest6.chestX && y == Chest6.chestY)
                        {
                            Chest6.Draw();
                        }

                        // Render Brutes
                        else if (x == Enemy1.mobX && y == Enemy1.mobY)
                        {
                            Enemy1.Draw();
                        }

                        // Render Player
                        else if (x == Player.playerX && y == Player.playerY)
                        {
                            Console.Write("@");
                        }

                        // Render Rest of Map
                        else
                        {
                            Console.Write(map[y][x]);
                        }
                    }
                    Console.Write("\r\n");
                }
                Console.WriteLine("Press, up, down, left, right or Q to quit");

                // Activating the AI method for Enemies
                foreach (Enemy e in Enemies)
                {
                    e.AI(Player, map);
                }

                /*RenderMap(playerX, playerY, mobX, mobY, map);*/

                // What is under neath me? 
                tile = map[Player.playerY][Player.playerX];
                Console.Write($"You are standing on {tile}");

                // Capture user input
                user_input = Console.ReadKey();
                if (user_input.Key == ConsoleKey.UpArrow)
                {
                    if (map[Player.playerY - 1][Player.playerX] != '#')
                    {
                        if (map[Player.playerY - 1][Player.playerX] != '+')
                        {
                            if (map[Player.playerY - 1][Player.playerX] != '~')
                            {
                                if (map[Player.playerY - 1][Player.playerX] != map[Enemy1.mobY][Enemy1.mobX])
                                {
                                    Player.playerY--;
                                }

                                else
                                {
                                    Console.Write("\nPress 'E' to ATTACK the Enemy!");
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
                            Console.Write("\nPress 'E' to OPEN the Door!");
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
                                Player.playerY++;
                            }
                        }

                        else
                        {
                            Console.Write("\nPress 'E' to OPEN the Door!");
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

                                else
                                {
                                    Console.Write("Press 'E' to ATTACK the Enemy!");
                                    if (user_input.Key == ConsoleKey.E)
                                    {
                                        Player.Attack();
                                    }
                                }
                            }
                        }

                        else
                        {
                            Console.Write("\nPress 'E' to OPEN the Door!");
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
