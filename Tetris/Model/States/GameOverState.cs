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
    public class GameOverState : IngameOptionState // This class represents the Game Over state of the game
    {
        public GameOverState(GameModel gameModel, List<Button> gameButtons) : base(State.GameOver, gameModel, gameButtons)
        {

        }

        public override void Update(GameEvent e)
        {
            Enum.TryParse(e.GetMessage()[0], out Event eventType);
            switch (eventType)
            {
                case Event.SaveScore:
                    SaveScore(e.GetMessage()[1]);
                    break;
                default: // Calls parent method like RestartGame() or QuitGame() if the player wants to restart or quit game respectively.
                    base.Update(e);
                    break;
            }
        }

        private void SaveScore(string playerName) // Calls this method when the player wants to save score (the score may not be saved if it's not in top 5)
        {
            if (GameModel.Game.GameMode == Mode.FortyLines && GameModel.Game.CurrentLevel[1] < 40) // Don't run if the player lose in 40 lines
            {
                ReturnToMenu();
                return;
            }
            BestScoreManager.Instance.Save(GameModel.Game, playerName);
            ReturnToMenu();
        }
    }
}
