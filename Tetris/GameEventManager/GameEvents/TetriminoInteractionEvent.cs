using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.GameEventManager.GameEvents
{
    public class TetriminoInteractionEvent : GameEvent
    {
        private string _direction;
        public TetriminoInteractionEvent(string direction) : base(Event.TetriminoInteraction) // This class represents a move/rotate/hard drop/hold tetrimino event information
        {
            _direction = direction;
        }

        public override string[] GetMessage() // Tetrimino Interaction Event also sends the direction the tetrimino is controlled
        {
            return [Name, _direction];
        }
        public string Direction
        {
            get
            {
                return _direction;
            }
        }
    }
}
