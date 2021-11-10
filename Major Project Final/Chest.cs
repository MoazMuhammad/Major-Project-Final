using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Major_Project_Final
{
    public class Chest
    {
        public State state = null;
        public int chestX;
        public int chestY;
        public List<Chest> chests;
        public List<Items> storage;
        public ConsoleKeyInfo user_input;

        public Chest(State _state, int _chestX, int _chestY, List<Chest> _chests, List<Items> _storage)
        {
            this.chestX = _chestX;
            this.chestY = _chestY;
            this.chests = _chests;
            this.storage = _storage;
            this.TransitionTo(_state);

            chests.Add(this);
        }

        public void TransitionTo(State _state)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            // Console.WriteLine("[UPDATE] Chest State: " + _state.GetType().Name);
            this.state = _state;
            this.state.SetChest(this);
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

        public void OpenChest(ConsoleKeyInfo _user_input)
        {
            Console.Clear();

            do
            {
                foreach (Items i in storage)
                {
                    Console.WriteLine(i.name);
                }

            } while (_user_input.Key != ConsoleKey.E);
        }
    }

    // Open state for Chests
    public class OpenChest : State
    {
        public override void NextState()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            this.door.TransitionTo(new ClosedChest());
            Console.ForegroundColor = ConsoleColor.White;
        }

        public override void StateAction()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("CLIENT: The Chest is Open!");
        }

        public override void Draw()
        {
            Console.Write("~");
        }
    }

    // Closed state for Chests
    public class ClosedChest : State
    {
        public override void NextState()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            this.door.TransitionTo(new OpenChest());
            Console.ForegroundColor = ConsoleColor.White;
        }

        public override void StateAction()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("CLIENT: The Chest is Closed!");
        }

        public override void Draw()
        {
            Console.Write("~");
        }
    }
}
