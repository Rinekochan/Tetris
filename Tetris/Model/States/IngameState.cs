using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;
using Tetris.GameEventManager;
using Tetris.GameEventManager.GameEvents;
using Tetris.Model.Components.Buttons;
using Tetris.Model.Logic;
using Tetris.Model.StateFactories;

namespace Tetris.Model.States
{
    public class IngameState : GameState // This class represents the Ingame state of the game
    {
        public IngameState(GameModel gameModel, List<Button> gameButtons) : base(State.Ingame, gameModel, gameButtons)
        {

        }

        public override void Update(GameEvent e)
        {
            Enum.TryParse(e.GetMessage()[0], out Event eventType);
            switch (eventType)
            {
                case Event.PauseGame:
                    PauseGame();
                    break;
                case Event.Tick: // Tick is called in the game loop
                    Run();
                    break;
            }
        }

        private void PauseGame() // Calls this method when the player pauses and enter PauseGame state
        {
            GameModel.EventManager.Detach(GameModel.Game); // Detach the previous GameLogic before moving to PauseGame state
            GameModel.Game.CurrentTick.Pause();
            GameModel.TransitionTo(new PauseMenuStateFactory());
        }

        private void Run() // This method calls repetitively methods. (In Tetris, a tetrimino is automatically move down over time)
        {
            if (GameModel.Game.GameOver) // If the game over is triggered, change to GameOver State
            {
                GameModel.TransitionTo(new GameOverStateFactory());
            }
            GameModel.Game.Run();
        }
    }
}
