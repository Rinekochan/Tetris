using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.GameEventManager.GameEvents;
using Tetris.Model.Components.Buttons;

namespace Tetris.Model.States
{
    // Represents an abstract state of the game, encapsulating the state, game model, and associated buttons.
    public abstract class GameState
    {
        private State _state;
        private GameModel _gameModel;
        private List<Button> _gameButtons;

        public GameState(State state, GameModel gameModel, List<Button> gameButtons)
        {
            _gameModel = gameModel;
            _state = state;
            _gameButtons = gameButtons;
        }

        public abstract void Update(GameEvent e);

        public List<Button> GameButtons
        {
            get
            {
                return _gameButtons;
            }
        }

        public GameModel GameModel
        {
            get
            {
                return _gameModel;
            }
        }

        public State CurrentState
        {
            get
            {
                return _state;
            }
        }
    }
}
