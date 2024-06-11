using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.GameEventManager;
using Tetris.GameEventManager.GameEvents;

namespace Tetris.Controller.Commands
{
    public class QuitGameCommand : GameCommand // This command calls the event to quit the game
    {
        public QuitGameCommand() : base(new string[] { "QKey", "Quit" }) { } // Player presses Q Key or clicks on Quit Button to use this command

        public override void Execute(EventManager eventManager)
        {
            eventManager.Post(new GameEvent(Event.QuitGame));
        }
    }
}
