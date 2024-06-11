using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Controller.Commands;

namespace Tetris.Controller.GameCommandProcessorFactories
{
    public class GameOverGameCommandProcessorFactory : GameCommandProcessorFactory // This class creates GameCommandProcessor behavior in Game Over state
    {
        public override List<GameCommand> LoadCommand() // Game Over State contains these commands
        {
            List<GameCommand> _commands =
            [
                new TypingCommand(),
                new SaveCommand(),
                new RestartGameCommand(),
                new ReturnToMenuCommand()
            ];
            return _commands;
        }
    }
}
