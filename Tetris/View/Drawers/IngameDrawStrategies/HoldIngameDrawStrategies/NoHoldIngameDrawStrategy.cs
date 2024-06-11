using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Model;

namespace Tetris.View.Drawers.IngameDrawStrategies.HoldIngameDrawStrategies
{
    public class NoHoldIngameDrawStrategy : IHoldIngameDrawStrategy // This class draws no-hold tetrimino if the game mode rules not allow to hold
    {
        public void DrawHold(GameModel gameModel)
        {
            SplashKit.DrawText("No Hold", Color.White, "Modern", 32, TextAlignment.HorizontalCenter("No Hold", "Modern", 32, 320, 180), TextAlignment.VerticalCenter("No Hold", "Modern", 32, 32, 150));
        }
    }
}
