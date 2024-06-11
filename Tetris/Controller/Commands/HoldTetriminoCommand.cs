using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.GameEventManager.GameEvents;
using Tetris.GameEventManager;

namespace Tetris.Controller.Commands
{
    public class HoldTetriminoCommand : GameCommand // This command calls the event to hold the tetrimino
    {
        public HoldTetriminoCommand() : base(new string[] { "LeftShiftKey", "CKey" }) { } // Player presses Left Shirt or C Key to use this command
        public override void Execute(EventManager eventManager)
        {
            eventManager.Post(new TetriminoInteractionEvent("Hold"));
        }
    }
}
