using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.GameEventManager.GameEvents;
using Tetris.GameEventManager;

namespace Tetris.Controller.Commands
{
    public class ReturnToMenuCommand : GameCommand // This command calls the event to return to the menu state
    {
        public ReturnToMenuCommand() : base(new string[] { "MKey", "ReturnToMenu" }) { } // Player presses M Key or clicks on Menu Button to use this command

        public override void Execute(EventManager eventManager)
        {
            eventManager.Post(new GameEvent(Event.ReturnToMenu));
        }
    }
}
