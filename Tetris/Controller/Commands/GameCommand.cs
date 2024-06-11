using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.GameEventManager;

namespace Tetris.Controller.Commands
{
    public abstract class GameCommand // This class represents all game commands that controls the game
    {
        private List<string> _input;

        public GameCommand(string[] input)
        {
            _input = input.ToList();
        }

        public bool AreYou(string name) // This is to check if KeyCode or the button the mouse is clicked is matched to the List in every commands
        {
            foreach (string input in _input)
            {
                if (input == name) return true;
            }
            return false;
        }

        public abstract void Execute(EventManager eventManager);

        public List<string> Input
        {
            get
            {
                return _input;
            }
        }
    }
}
