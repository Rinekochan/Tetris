using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.GameEventManager;
using Tetris.GameEventManager.GameEvents;

namespace Tetris.Controller.Commands
{
    public class MoveLeftCommand : GameCommand // This command calls the event to move the tetrimino left
    {
        public MoveLeftCommand() : base(new string[] { "LeftKey" }) { } // Player presses arrow left key to use this command
        public override void Execute(EventManager eventManager)
        {
            eventManager.Post(new TetriminoInteractionEvent("Left"));
        }
    }
}
