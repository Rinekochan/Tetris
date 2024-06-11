using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.GameEventManager.GameEvents;
using Tetris.Model.Components.Buttons;
using Tetris.Model.StateFactories;

namespace Tetris.Model.States
{
    public class NotInitializedState : GameState // This state represents the game before it is initialized
    {
        public NotInitializedState(GameModel gameModel, List<Button> gameButtons) : base(State.NotInitialized, gameModel, gameButtons)
        {

        }

        public override void Update(GameEvent e)
        {
            Enum.TryParse(e.GetMessage()[0], out Event eventType);
            if (eventType == Event.Initialize) Initialize();
        }

        private void Initialize()
        {
            GameModel.GameRunning = true;
            GameModel.TransitionTo(new MenuStateFactory());
        }
    }
}
