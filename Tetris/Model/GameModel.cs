using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;
using Tetris.GameEventManager;
using Tetris.GameEventManager.GameEvents;
using Tetris.Model.Components.Buttons;
using Tetris.Model.Factories;
using Tetris.Model.Logic;
using Tetris.Model.StateFactories;
using Tetris.Model.States;

namespace Tetris.Model
{
    public class GameModel : IEventListener
    {
        private EventManager _eventManager;
        private GameState _currentState; 
        private IGameLogic _gameLogic;
        private bool _gameRunning;
        public GameModel(EventManager eventManager) // This class represents the Game Model in MVC architecture, it holds Game Logic and the game states informations
        {
            _eventManager = eventManager;
            _eventManager.Attach(this);
            _gameRunning = true;

            // Default behaviours, these variables will be specified by events later
            _currentState = new NotInitializedStateFactory().Create(this);
            _gameLogic = GameLogicFactory.Create(Mode.Classic, _eventManager);
        }

        public void Update(GameEvent e) // Game Model will be updated differently depends on current game state
        {
            _currentState.Update(e);
        }

        public void TransitionTo(IGameStateFactory gameStateFactory) // This method will be used to switch from one state to another 
        {
            _currentState = gameStateFactory.Create(this); // Delegate state creation process to factory
            _eventManager.Post(new StateChangeEvent(_currentState.CurrentState)); // It will also post state change event to listeners
        }

      
        public EventManager EventManager
        {
            get
            {
                return _eventManager;
            }
        }

        public IGameLogic Game
        {
            get
            {
                return _gameLogic;
            }
            set
            {
                _gameLogic = value;
            }
        }

        public bool GameRunning
        {
            get
            {
                return _gameRunning;
            }
            set
            {
                _gameRunning = value;
            }
        }

        public List<Button> GameButtons
        {
            get
            {
                return _currentState.GameButtons;
            }
        }
    }
}
