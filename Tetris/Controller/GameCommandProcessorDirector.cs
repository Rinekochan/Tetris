using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Tetris.Controller.Commands;
using Tetris.Controller.GameCommandProcessorFactories;

namespace Tetris.Controller
{
    public static class GameCommandProcessorDirector // This class choose which factory to use to create GameCommandProcessor
    {
        public static GameCommandProcessor Create(State state) 
        {
            GameCommandProcessorFactory gameCommandProcessorFactory;
            switch (state)
            {
                case State.Menu:
                    gameCommandProcessorFactory = new MenuGameCommandProcessorFactory();
                    break;
                case State.Help:
                    gameCommandProcessorFactory = new HelpGameCommandProcessorFactory();
                    break;
                case State.Ingame:
                    gameCommandProcessorFactory = new IngameCommandProcessorFactory();
                    break;
                case State.PauseMenu:
                    gameCommandProcessorFactory = new PauseMenuGameCommandProcessorFactory();
                    break;
                case State.GameOver:
                    gameCommandProcessorFactory = new GameOverGameCommandProcessorFactory();
                    break;
                default:
                    throw new Exception($"Unable to create GameCommandProcessor with unknown state {state}");
            }
            return gameCommandProcessorFactory.Create();
        }
    }
}
