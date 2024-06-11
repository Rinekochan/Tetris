using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Controller.Commands;

namespace Tetris.Controller.GameCommandProcessorFactories
{
    public class IngameCommandProcessorFactory : GameCommandProcessorFactory // This class creates GameCommandProcessor behavior in Ingame State
    {
        public override List<GameCommand> LoadCommand() // Ingame State contains these commands
        {
            List<GameCommand> _commands =
            [
                new MoveDownCommand(),
                new MoveLeftCommand(),
                new MoveRightCommand(),
                new HardDropCommand(),
                new RotateCWCommand(),
                new RotateCCWCommand(),
                new HoldTetriminoCommand(),
                new PauseGameCommand()
            ];
            return _commands;
        }
    }
}
