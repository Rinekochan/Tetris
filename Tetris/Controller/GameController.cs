using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.GameEventManager;
using Tetris.GameEventManager.GameEvents;
using Tetris.Model;

namespace Tetris.Controller
{
    public class GameController : IEventListener // This class represents Controller in MVC architecture, know what GameCommandProcessor needs to be used and delegates command execution task to GameCommandProcessor based on events.
    {
        private EventManager _eventManager;
        private GameModel _gameModel;
        private GameCommandProcessor _gameCommandProcessor;

        public GameController(GameModel gameModel, EventManager eventManager)
        {
            _eventManager = eventManager;
            _eventManager.Attach(this);
            _gameModel = gameModel;
            _gameCommandProcessor = GameCommandProcessorDirector.Create(State.Menu); // Default behaviour
        }

        public void Update(GameEvent e)
        {
            Enum.TryParse(e.GetMessage()[0], out Event eventType);
            switch (eventType)
            {
                case Event.StateChange: // Change GameCommandProcessor when the state changes
                    Enum.TryParse(e.GetMessage()[1], out State state);
                    _gameCommandProcessor = GameCommandProcessorDirector.Create(state); // Delegate GameCommandProcessor creation to factory
                    break;
                default: // Delegates other events to gameCommandProcessor
                    _gameCommandProcessor.Execute(_eventManager, e.GetMessage(), _gameModel.GameButtons);
                    break;
            }
        }
    }
}
