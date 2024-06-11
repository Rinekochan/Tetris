using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.GameEventManager;
using Tetris.GameEventManager.GameEvents;

namespace Tetris.Controller.Commands
{
    public class RotateCCWCommand : GameCommand // This command calls the event to rotate the tetrimino counter close wise 
    {
        public RotateCCWCommand() : base(new string[] { "ZKey" }) { } // Player presses Z Key to use this command
        public override void Execute(EventManager eventManager)
        {
            eventManager.Post(new TetriminoInteractionEvent("CCW"));
        }
    }
}
