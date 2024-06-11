using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.GameEventManager.GameEvents;
using Tetris.GameEventManager;

namespace Tetris.Controller.Commands
{
    public class NewClassicGameCommand : GameCommand // This command calls the event to create a new Classic Game
    {
        public NewClassicGameCommand() : base(new string[] { "Num1Key", "Classic" }) { } // Player presses Number 1 Key or clicks on Classic Button to use this command

        public override void Execute(EventManager eventManager)
        {
            eventManager.Post(new NewGameEvent(Mode.Classic));
        }
    }
}
