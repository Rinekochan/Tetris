using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.GameEventManager.GameEvents;
using Tetris.GameEventManager;

namespace Tetris.Controller.Commands
{
    internal class NewNESGameCommand : GameCommand // This command calls the event to create a new NES Game
    {
        public NewNESGameCommand() : base(new string[] { "Num2Key", "NES" }) { } // Player presses Number 2 Key or clicks on NES Button to use this command

        public override void Execute(EventManager eventManager)
        {
            eventManager.Post(new NewGameEvent(Mode.NES));
        }
    }
}
