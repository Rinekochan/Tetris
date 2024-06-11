using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.GameEventManager.GameEvents;
using Tetris.GameEventManager;

namespace Tetris.Controller.Commands
{
    public class ResumeGameCommand : GameCommand // This command calls the event to resume the game (the game logic)
    {
        public ResumeGameCommand() : base(new string[] { "ReturnKey", "Resume" }) { } // Player presses Enter Key or clicks on Resume Button to use this command

        public override void Execute(EventManager eventManager)
        {
            eventManager.Post(new GameEvent(Event.ResumeGame));
        }
    }
}
