using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Major_Project
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
            //To see what I am standing on
            char tile;
            
            // Player Inventory List
            List<Items> Inventory = new List<Items>();

            // Chest Storage List
            List<Items> ChestStorage = new List<Items>();
            ChestStorage.Add(new HealingPotion("Healing Potion"));
            ChestStorage.Add(new HealingPotion("Healing Potion"));

            // Enemies List
            List<Enemy> Enemies = new List<Enemy>();

            // Interactables Lists
            // Door Lists
            List<Door> Doors = new List<Door>();
            
            // Chest Lists
            List<Chest> Chests = new List<Chest>();

            // Potions
            Potions Potions = new Potions("Potions");

            Inventory.Add(new HealingPotion("Healing Potion"));
            Inventory.Add(new SpeedPotion("Speed Potion"));

            // Weapons
            Client client = new Client();
            IronSword IronSword = new IronSword();

            // Player
            Player Player = new Player(100, 3, 3, IronSword);

            // Enemies
            Enemy Enemy1 = new Enemy(50, 8, 3, Enemies, 20);

            // Doors
            Door door1 = new Door(new ClosedDoor(), 3, 5, Doors);
            Door door2 = new Door(new ClosedDoor(), 9, 2, Doors);
            Door door3 = new Door(new ClosedDoor(), 19, 4, Doors);
            Door door4 = new Door(new ClosedDoor(), 49, 7, Doors);
            Door door5 = new Door(new ClosedDoor(), 56, 11, Doors);
            Door door6 = new Door(new ClosedDoor(), 16, 13, Doors);
            Door door7 = new Door(new ClosedDoor(), 32, 17, Doors);
            Door door8 = new Door(new ClosedDoor(), 43, 24, Doors);
            Door door9 = new Door(new ClosedDoor(), 22, 32, Doors);

            //This path will read a map from your project directory//
            // School
            var path = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, @"\\nas125e2.actedu.net.au\studenthome\Born2004\09\0083844\My Documents\Visual Studio 2015\Projects\Major Project\Major Project\Map.txt");
            // Home
            //var path = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, @"C:\Users\PC\OneDrive\Desktop\Canberra College\Programming\Assignments\Major Project Final\Major Project Final\map.txt");
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
                        if (x == door1.doorX && y == door1.doorY)
                        {
                            door1.Draw();
                        }

                        else if (x == door2.doorX && y == door2.doorY)
                        {
                            door2.Draw();
                        }

                        else if (x == door3.doorX && y == door3.doorY)
                        {
                            door3.Draw();
                        }

                        else if (x == door4.doorX && y == door4.doorY)
                        {
                            door4.Draw();
                        }

                        else if (x == door5.doorX && y == door5.doorY)
                        {
                            door5.Draw();
                        }

                        else if (x == door6.doorX && y == door6.doorY)
                        {
                            door6.Draw();
                        }

                        else if (x == door7.doorX && y == door7.doorY)
                        {
                            door7.Draw();
                        }

                        else if (x == door8.doorX && y == door8.doorY)
                        {
                            door8.Draw();
                        }

                        else if (x == door9.doorX && y == door9.doorY)
                        {
                            door9.Draw();
                        }

                        // Render Chests
                        else if (map[y][x] == '~')
                        {
                            Chest c = new Chest(new ClosedChest(), x, y, Chests, ChestStorage);
                            c.Draw();
                        }

                        // Render Enemies
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

                // Interaction with Enemies
                foreach (Enemy e in Enemies)
                {
                    // Activating the AI method for Enemies
                    e.AI(Player, map);
                }

                // What is under neath me? 
                tile = map[Player.playerY][Player.playerX];
                Console.Write($"You are standing on {tile}");

                // Capture user input
                user_input = Console.ReadKey();

                // Inventory
                if (user_input.Key == ConsoleKey.I)
                {
                    Menu.Inventory(Inventory, user_input);
                }

                // Movement 
                // Move Up
                else if (user_input.Key == ConsoleKey.UpArrow)
                {
                    if (map[Player.playerY - 1][Player.playerX] != '#' && map[Player.playerY - 1][Player.playerX] != 'E' && map[Player.playerY - 1][Player.playerX] != '+' && map[Player.playerY - 1][Player.playerX] != '~')
                    {
                        Player.playerY--;
                    }
                }

                // Move Down
                else if (user_input.Key == ConsoleKey.DownArrow)
                {
                    if (map[Player.playerY + 1][Player.playerX] != '#' && map[Player.playerY + 1][Player.playerX] != 'E' && map[Player.playerY + 1][Player.playerX] != '+' && map[Player.playerY + 1][Player.playerX] != '~')
                    {
                        Player.playerY++;
                    }
                }

                // Move Right
                else if (user_input.Key == ConsoleKey.RightArrow)
                {
                    if (map[Player.playerY][Player.playerX + 1] != '#' && map[Player.playerY][Player.playerX + 1] != 'E' && map[Player.playerY][Player.playerX + 1] != '+' && map[Player.playerY][Player.playerX + 1] != '~')
                    {
                        Player.playerX++;
                    }
                }

                // Move Left
                else if (user_input.Key == ConsoleKey.LeftArrow)
                {
                    // Collision Detection
                    if (map[Player.playerY][Player.playerX - 1] != '#' && map[Player.playerY][Player.playerX - 1] != 'E' && map[Player.playerY][Player.playerX - 1] != '+' && map[Player.playerY][Player.playerX - 1] != '~')
                    {
                        Player.playerX--;
                    }
                }

                // Interaction with Doors
                foreach (Door d in Doors)
                {
                    d.ToggleDoor(Player, map, user_input);
                }

                // Intercation with Chests
                foreach (Chest c in Chests)
                {
                    // If Player is South of Chest
                    if (map[Player.playerY - 1][Player.playerX] == map[c.chestY][c.chestX])
                    {
                        if (user_input.Key == ConsoleKey.E)
                        {
                            c.OpenChest(user_input);
                        }
                    }
                }

            } while (user_input.Key != ConsoleKey.Q);
        }
    }
}
