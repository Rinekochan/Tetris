using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.GameEventManager.GameEvents;
using Tetris.GameEventManager;

namespace Tetris.Controller.Commands
{
    public class OpenHelpCommand: GameCommand // This command calls the event to open the Help Page
    {
        public OpenHelpCommand() : base(new string[] { "HKey", "Help" }) { } // Player presses H Key or clicks on Help Button to use this command

        public override void Execute(EventManager eventManager)
        {
            eventManager.Post(new GameEvent(Event.OpenHelp));
        }
    }
}
