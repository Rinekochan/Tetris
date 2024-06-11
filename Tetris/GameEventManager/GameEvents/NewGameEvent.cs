using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.GameEventManager.GameEvents
{
    public class NewGameEvent : GameEvent
    {
        private Mode _mode;

        public NewGameEvent(Mode mode) : base(Event.NewGame) // This class represents a new game event information
        {
            _mode = mode;
        }

        public override string[] GetMessage() // New Game Event also sends the requested game mode 
        {
            return [Name, _mode.ToString()];
        }

        public Mode Mode
        {
            get
            {
                return _mode;
            }
        }
    }
}
