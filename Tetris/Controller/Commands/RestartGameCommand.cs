using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.GameEventManager.GameEvents;
using Tetris.GameEventManager;

namespace Tetris.Controller.Commands
{
    internal class RestartGameCommand : GameCommand // This command calls the event to restart the game (the game logic)
    {
        public RestartGameCommand() : base(new string[] { "SKey", "Restart" }) { } // Player presses S Key or clicks on Restart Button to use this command

        public override void Execute(EventManager eventManager)
        {
            eventManager.Post(new GameEvent(Event.RestartGame));
        }
    }
}
