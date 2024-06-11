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
    public class MenuStateFactory : IGameStateFactory // separates/encapsulates the creation process of MenuState from logic
    {
        public GameState Create(GameModel gameModel)
        {
            List<Button> gameButtons = CreateButton();
            return new MenuState(gameModel, gameButtons);
        }

        public List<Button> CreateButton() // Create buttons for Menu State.
        {
            Color menuButtonColor = Color.RGBColor(254, 223, 115);
            Color boxColor = Color.RGBColor(49, 60, 83);
            List< Button> gameButtons =
            [
                new RectangleButtonBuilder("Classic").SetPosition(490, 221).SetSize(300, 28).SetColor(menuButtonColor).Build(),
                new RectangleButtonBuilder("NES").SetPosition(490, 283).SetSize(300, 28).SetColor(menuButtonColor).Build(),
                new RectangleButtonBuilder("FortyLines").SetPosition(490, 347).SetSize(300, 28).SetColor(menuButtonColor).Build(),
                new RectangleButtonBuilder("Blitz").SetPosition(490, 412).SetSize(300, 28).SetColor(menuButtonColor).Build(),
                new RectangleButtonBuilder("Help").SetPosition(570, 480).SetSize(140, 24).SetColor(menuButtonColor).Build(),
                new RectangleButtonBuilder("Quit").SetPosition(512, 536).SetSize(257, 22).SetColor(menuButtonColor).Build(),
            ];
            return gameButtons;
        }
    }
}
