using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.GameEventManager;
using Tetris.GameEventManager.GameEvents;

namespace Tetris.Controller.Commands
{
    public class HardDropCommand : GameCommand // This command calls the event to make the tetrimino hard drop
    {
        public HardDropCommand() : base(new string[] { "SpaceKey" }) { } // Player presses Space Bar Key to use this command
        public override void Execute(EventManager eventManager)
        {
            eventManager.Post(new TetriminoInteractionEvent("Hard"));
        }
    }
}
