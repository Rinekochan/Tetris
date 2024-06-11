using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.GameEventManager;
using Tetris.GameEventManager.GameEvents;

namespace Tetris.Controller.Commands
{
    public class RotateCWCommand : GameCommand // This command calls the event to rotate the tetrimino close wise
    {
        public RotateCWCommand() : base(new string[] { "XKey", "UpKey" }) { } // Player presses X Key or Arrow Up to use this command
        public override void Execute(EventManager eventManager)
        {
            eventManager.Post(new TetriminoInteractionEvent("CW"));
        }
    }
}
