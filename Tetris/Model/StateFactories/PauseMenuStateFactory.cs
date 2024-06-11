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
    public class PauseMenuStateFactory : IGameStateFactory // separates/encapsulates the creation process of PauseMenuState from logic
    {
        public GameState Create(GameModel gameModel)
        {
            List<Button> gameButtons = CreateButton();
            return new PauseMenuState(gameModel, gameButtons);
        }

        public List<Button> CreateButton() // Create buttons for PauseMenu State.
        {
            List<Button> gameButtons = 
            [
                new RectangleButtonBuilder("Resume").SetPosition(390, 270).SetSize(500, 70).SetColor(Color.Black).Build(),
                new RectangleButtonBuilder("Restart").SetPosition(390, 370).SetSize(500, 70).SetColor(Color.Black).Build(),
                new RectangleButtonBuilder("ReturnToMenu").SetPosition(390, 470).SetSize(500, 70).SetColor(Color.Black).Build(),
            ];

            return gameButtons;
        }
    }
}
