using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Major_Project
{
    public class Door
    {
        public State state = null;
        public int doorX;
        public int doorY;
        public List<Door> doors;
        ConsoleKeyInfo user_input;
        Player Player;
        string[] map;

        public Door(State _state, int _doorX, int _doorY, List<Door> _doors)
        {
            this.doorX = _doorX;
            this.doorY = _doorY;
            this.TransitionTo(_state);
            this.doors = _doors;

            doors.Add(this);
        }

        public void TransitionTo(State _state)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            // Console.WriteLine("[UPDATE] Door State: " + _state.GetType().Name);
            this.state = _state;
            this.state.SetDoor(this);
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
            state.Draw();
        }

        public void ToggleDoor(Player _player, string[] _map, ConsoleKeyInfo _user_input)
        {
            this.map = _map;
            this.Player = _player;
            this.user_input = _user_input;

            // If Player North of Door
            if (map[Player.playerY + 1][Player.playerX] == '+' && user_input.Key == ConsoleKey.E)
            {
                Console.WriteLine("\nPress 'E' to Open Door");
                this.Request1();
            }

            // If Player South of Door
            else if (map[Player.playerY - 1][Player.playerX] == '+' && user_input.Key == ConsoleKey.E)
            {
                Console.WriteLine("\nPress 'E' to Open Door");
                this.Request1();
            }

            // If player West of Door
            else if (map[Player.playerY][Player.playerX + 1] == '+' && user_input.Key == ConsoleKey.E)
            {
                Console.WriteLine("\nPress 'E' to Open Door");
                this.Request1();
            }

            // If player East of Door
            else if (map[Player.playerY][Player.playerX - 1] == '+' && user_input.Key == ConsoleKey.E)
            {
                Console.WriteLine("\nPress 'E' to Open Door");
                this.Request1();
            }
        }
    }

    // Open state for Doors
    public class OpenDoor : State
    {
        public override void NextState()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            this.door.TransitionTo(new ClosedDoor());
            Console.ForegroundColor = ConsoleColor.White;
        }

        public override void StateAction()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("CLIENT: The Door is Open!");
        }

        public override void Draw()
        {
            Console.Write("-");
        }
    }

    // Closed state for Doors
    public class ClosedDoor : State
    {
        public override void NextState()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            this.door.TransitionTo(new OpenDoor());
            Console.ForegroundColor = ConsoleColor.White;
        }

        public override void StateAction()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("CLIENT: The Door is Closed!");
        }

        public override void Draw()
        {
            Console.Write("+");
        }
    }
}
