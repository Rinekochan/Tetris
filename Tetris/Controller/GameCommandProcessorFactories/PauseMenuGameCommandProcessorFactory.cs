using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Controller.Commands;

namespace Tetris.Controller.GameCommandProcessorFactories
{
    public class PauseMenuGameCommandProcessorFactory : GameCommandProcessorFactory  // This class creates GameCommandProcessor behavior in Pause Menu State
    {
        public override List<GameCommand> LoadCommand() // Pause Menu State contains these commands
        {
            List<GameCommand> _commands =
            [
                new ResumeGameCommand(),
                new RestartGameCommand(),
                new ReturnToMenuCommand()
            ];
            return _commands;
        }
    }
}
