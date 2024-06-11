using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Controller.Commands;

namespace Tetris.Controller.GameCommandProcessorFactories
{
    public abstract class GameCommandProcessorFactory // This class encapsulates the creation process of GameCommandProcessor
    {
        public GameCommandProcessor Create()
        {
             return new GameCommandProcessor(LoadCommand());
        }
        public abstract List<GameCommand> LoadCommand();
    }
}
