using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Major_Project_Final
{
    public class Door
    {
        public State state = null;
        public int doorX;
        public int doorY;
        public List<Door> doors;
        ConsoleKeyInfo user_input;
        Player player;
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
