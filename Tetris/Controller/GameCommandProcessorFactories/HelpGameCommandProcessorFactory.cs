using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Controller.Commands;

namespace Tetris.Controller.GameCommandProcessorFactories
{
    public class HelpGameCommandProcessorFactory : GameCommandProcessorFactory // This class creates GameCommandProcessor behavior in Help State
    {
        public override List<GameCommand> LoadCommand() // Help State contains these commands
        {
            List<GameCommand> _commands =
            [
                new ReturnToMenuCommand(),
            ];
            return _commands;
        }
    }
}
