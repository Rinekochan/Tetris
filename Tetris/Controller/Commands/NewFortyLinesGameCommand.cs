using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.GameEventManager.GameEvents;
using Tetris.GameEventManager;

namespace Tetris.Controller.Commands
{
    public class NewFortyLinesGameCommand : GameCommand // This command calls the event to create a new Forty Lines Game
    {
        public NewFortyLinesGameCommand() : base(new string[] { "Num3Key", "FortyLines" }) { } // Player presses Number 3 Key or clicks on Forty Lines Button to use this command

        public override void Execute(EventManager eventManager)
        {
            eventManager.Post(new NewGameEvent(Mode.FortyLines));
        }
    }
}
