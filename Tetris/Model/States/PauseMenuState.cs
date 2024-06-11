using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.GameEventManager.GameEvents;
using Tetris.Model.Components.Buttons;
using Tetris.Model.Logic;
using Tetris.Model.StateFactories;

namespace Tetris.Model.States
{
    public class PauseMenuState : IngameOptionState // This class represents the Pause Menu state of the game
    {
        public PauseMenuState(GameModel gameModel, List<Button> gameButtons) : base(State.PauseMenu, gameModel, gameButtons)
        {

        }

        public override void Update(GameEvent e)
        {
            Enum.TryParse(e.GetMessage()[0], out Event eventType);
            switch (eventType)
            {
                case Event.ResumeGame:
                    ResumeGame();
                    break;
                default: // Calls parent method like RestartGame() or QuitGame() if the player wants to restart or quit game respectively.
                    base.Update(e);
                    break;
            }
        }

        private void ResumeGame() // Calls this method when the player wants to resume playing current GameLogic 
        {
            GameModel.Game.CurrentTick.Resume();
            GameModel.EventManager.Attach(GameModel.Game); // Attach the game logic again when the player is in Ingame state
            GameModel.TransitionTo(new IngameStateFactory());
        }
    }
}
