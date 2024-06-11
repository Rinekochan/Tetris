using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Controller.Commands;

namespace Tetris.Controller.GameCommandProcessorFactories
{
    public class MenuGameCommandProcessorFactory : GameCommandProcessorFactory // This class creates GameCommandProcessor behavior in Menu State
    {
        public override List<GameCommand> LoadCommand() // Menu State contains these commands
        {
            List<GameCommand> _commands =
            [
                new NewClassicGameCommand(),
                new NewNESGameCommand(),
                new NewFortyLinesGameCommand(),
                new NewBlitzGameCommand(),
                new OpenHelpCommand(),
                new QuitGameCommand(),
            ];
            return _commands;
        }
    }
}
