using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Model.Components.ButtonBuilders;
using Tetris.Model.Components.Buttons;
using Tetris.Model.States;

namespace Tetris.Model.StateFactories
{
    public class IngameStateFactory : IGameStateFactory // separates/encapsulates the creation process of IngameState from logic
    {
        public GameState Create(GameModel gameModel)
        {
            List<Button> gameButtons = CreateButton();
            return new IngameState(gameModel, gameButtons);
        }

        public List<Button> CreateButton() // Create buttons for Ingame State.
        {
            List<Button> gameButtons =
            [
                new RectangleButtonBuilder("Score").SetPosition(802, 32).SetSize(180, 160).SetBorderSize(2).Build(),
                new RectangleButtonBuilder("Hold").SetPosition(320, 32).SetSize(180, 150).SetBorderSize(2).Build(),
                new RectangleButtonBuilder("Mode").SetPosition(320, 182).SetSize(180, 88).SetBorderSize(2).Build(),
            ];
            return gameButtons;
        }
    }
}
