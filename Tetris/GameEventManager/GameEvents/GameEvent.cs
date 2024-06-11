using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.GameEventManager.GameEvents
{
    public class GameEvent // This class represents basic event in the game (like Tick, NewGame, QuitGame, ...)
    {
        private Event _name;

        public GameEvent(Event name)
        {
            _name = name;
        }

        public virtual string[] GetMessage() // Basic event only need to return their name 
        {
            return [_name.ToString()]; // The first string of the message is always the event name/type
        }

        public string Name
        {
            get
            {
                return _name.ToString();
            }
        }
    }
}
