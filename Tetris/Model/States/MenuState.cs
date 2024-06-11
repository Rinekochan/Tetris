using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.GameEventManager.GameEvents;
using Tetris.Model.Components.Buttons;
using Tetris.Model.Factories;
using Tetris.Model.Logic;
using Tetris.Model.StateFactories;

namespace Tetris.Model.States
{
    public class MenuState : GameState // This class represents the Menu state of the game
    {
        public MenuState(GameModel gameModel, List<Button> gameButtons) : base(State.Menu, gameModel, gameButtons)
        {

        }

        public override void Update(GameEvent e)
        {
            Enum.TryParse(e.GetMessage()[0], out Event eventType);
            switch (eventType)
            {
                case Event.OpenHelp:
                    OpenHelp();
                    break;
                case Event.NewGame:
                    Enum.TryParse(e.GetMessage()[1], out Mode gameMode);
                    NewGame(gameMode);
                    break;
                case Event.QuitGame:
                    QuitGame();
                    break;
            }
        }

        private void OpenHelp() // Calls this method when player wants to open help screen
        {
            GameModel.TransitionTo(new HelpStateFactory());
        }

        private void NewGame(Mode gameMode) // Calls this method when the player enters Ingame state
        {
            GameModel.Game = GameLogicFactory.Create(gameMode, GameModel.EventManager);
            GameModel.EventManager.Attach(GameModel.Game); // Attach to receives move and rotate tetrimino event.
            GameModel.Game.CurrentTick.Start();
            GameModel.TransitionTo(new IngameStateFactory());
        }

        private void QuitGame() // Calls this method when the player close the game
        {
            GameModel.GameRunning = false; // The game window close after this method
        }
    }
}
