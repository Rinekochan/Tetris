using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.GameEventManager;
using Tetris.GameEventManager.GameEvents;

namespace Tetris.Controller.Commands
{
    public class MoveDownCommand : GameCommand // This command calls the event to move the tetrimino down
    {
        public MoveDownCommand() : base(new string[] { "DownKey" }) { } // Player presses arrow down key to use this command
        public override void Execute(EventManager eventManager)
        {
            eventManager.Post(new TetriminoInteractionEvent("Down"));
        }
    }
}
