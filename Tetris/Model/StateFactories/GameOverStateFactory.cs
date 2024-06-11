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
    public class GameOverStateFactory : IGameStateFactory // separates/encapsulates the creation process of GameOverState from logic
    {
        public GameState Create(GameModel gameModel)
        {
            List<Button> gameButtons = CreateButton();
            return new GameOverState(gameModel, gameButtons);
        }

        public List<Button> CreateButton() // Create buttons for GameOver State.
        {
            List<Button> gameButtons =
            [
                new RectangleButtonBuilder("Typing").SetPosition(490, 460).SetSize(300, 60).SetBorderSize(2).Build(),
                new RectangleButtonBuilder("Save").SetPosition(820, 460).SetSize(125, 60).SetColor(Color.Gray).SetBorderSize(2).Build(),
                new RectangleButtonBuilder("Restart").SetPosition(390, 540).SetSize(500, 70).SetColor(Color.Black).Build(),
                new RectangleButtonBuilder("ReturnToMenu").SetPosition(390, 620).SetSize(500, 70).SetColor(Color.Black).Build(),
            ];
            return gameButtons;
        }
    }
}
