using SplashKitSDK;
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
    public class HelpStateFactory : IGameStateFactory // separates/encapsulates the creation process of HelpState from logic
    {
        public GameState Create(GameModel gameModel)
        {
            List<Button> gameButtons = CreateButton();
            return new HelpState(gameModel, gameButtons);
        }

        public List<Button> CreateButton() // Create buttons for Help State.
        {
            List<Button> gameButtons =
            [
                new RectangleButtonBuilder("ReturnToMenu").SetPosition(20, 10).SetSize(100, 40).SetColor(Color.DarkBlue).Build(),
            ];
            return gameButtons;
        }
    }
}
