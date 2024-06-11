using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Model.Components.Buttons;
using Tetris.Model.States;

namespace Tetris.Model.StateFactories
{
    public class NotInitializedStateFactory : IGameStateFactory // separates/encapsulates the creation process of NotInitializedState from logic
    {
        public GameState Create(GameModel gameModel)
        {
            List<Button> gameButtons = CreateButton();
            return new NotInitializedState(gameModel, gameButtons);
        }

        public List<Button> CreateButton() // There's no button in the NotInitalized State.
        {
            return new List<Button>() { };
        }
    }
}
