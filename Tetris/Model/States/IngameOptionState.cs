using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.GameEventManager;
using Tetris.GameEventManager.GameEvents;
using Tetris.Model.Components.Buttons;
using Tetris.Model.Factories;
using Tetris.Model.Logic;
using Tetris.Model.StateFactories;

namespace Tetris.Model.States
{
    // This class encapsulates the Ingame Option for PauseMenuStae and GameOverState of the game (for restart or return to menu)
    public abstract class IngameOptionState : GameState 
    {
        public IngameOptionState(State state, GameModel gameModel, List<Button> gameButtons) : base(state, gameModel, gameButtons)
        {

        }

        public override void Update(GameEvent e)
        {
            Enum.TryParse(e.GetMessage()[0], out Event eventType);
            switch (eventType)
            {
                case Event.RestartGame:
                    RestartGame();
                    break;
                case Event.ReturnToMenu: 
                    ReturnToMenu();
                    break;
            }
        }

        protected void RestartGame() // Calls this method when the player wants to restart to play a new game in Ingame state
        {
            Mode currentGameMode = GameModel.Game.GameMode;
            GameModel.Game.CurrentTick.Stop(); // Reset/removes the timer before create a new one
            GameModel.EventManager.Detach(GameModel.Game); // Detach the previous GameLogic to Attach the new one
            GameModel.Game = GameLogicFactory.Create(currentGameMode, GameModel.EventManager);
            GameModel.EventManager.Attach(GameModel.Game);
            GameModel.Game.CurrentTick.Start();
            GameModel.TransitionTo(new IngameStateFactory());
        }

        protected void ReturnToMenu() // Calls this method when the player wants to leave the current GameLogic and return to the menu
        {
            //Apply default behavior of GameLogic when returns to menu
            GameModel.EventManager.Detach(GameModel.Game); // Detach the previous GameLogic to Attach the new one
            GameModel.Game.CurrentTick.Stop(); // Reset/removes the timer before create a new one
            GameModel.Game = GameLogicFactory.Create(Mode.Classic, GameModel.EventManager); // default behaviour of game logic at menu
            GameModel.TransitionTo(new MenuStateFactory());
        }
    }
}
