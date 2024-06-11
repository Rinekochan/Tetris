using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.GameEventManager.GameEvents
{
    public class StateChangeEvent : GameEvent
    {
        private State _state;
        public StateChangeEvent(State state) : base(Event.StateChange) // This event represents a game State Change
        {
            _state = state;
        }

        public override string[] GetMessage() // State Change Event also sends the requested state to change
        {
            return [Name, _state.ToString()];
        }
        public State State
        {
            get
            {
                return _state;
            }
        }
    }
}
