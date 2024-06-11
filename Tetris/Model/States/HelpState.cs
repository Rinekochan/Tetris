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
    public class HelpState : GameState // This class represents the Help state of the game
    {
        public HelpState(GameModel gameModel, List<Button> gameButtons) : base(State.Help, gameModel, gameButtons)
        {

        }

        public override void Update(GameEvent e)
        {
            Enum.TryParse(e.GetMessage()[0], out Event eventType);
            switch (eventType)
            {
                case Event.ReturnToMenu:
                    CloseHelp();
                    break;
            }
        }

        private void CloseHelp() // Calls this method when the player wants to go back to menu screen
        {
            GameModel.TransitionTo(new MenuStateFactory());
        }
    }
}
