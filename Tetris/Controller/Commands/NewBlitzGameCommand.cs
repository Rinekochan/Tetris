using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.GameEventManager.GameEvents;
using Tetris.GameEventManager;

namespace Tetris.Controller.Commands
{
    public class NewBlitzGameCommand : GameCommand // This command calls the event to create a new Blitz Game
    {
        public NewBlitzGameCommand() : base(new string[] { "Num4Key", "Blitz" }) { } // Player presses Number 4 Key or clicks on Blitz Button to use this command

        public override void Execute(EventManager eventManager)
        {
            eventManager.Post(new NewGameEvent(Mode.Blitz));
        }
    }
}
