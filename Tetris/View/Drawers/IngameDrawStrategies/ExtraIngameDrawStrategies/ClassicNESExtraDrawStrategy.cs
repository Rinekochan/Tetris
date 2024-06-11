using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Model;
using Tetris.Model.Components.ButtonBuilders;

namespace Tetris.View.Drawers.IngameDrawStrategies.ExtraIngameDrawStrategies
{
    public class ClassicNESExtraDrawStrategy : IExtraIngameDrawStrategy // This class draws extra information of Classic and NES game mode in Ingame State
    {
        public void DrawExtra(GameModel gameModel)
        {
            // Draw button for extra informations in Classic and NES Game Mode
            new RectangleButtonBuilder("Others").SetPosition(320, 330).SetSize(180, 240).SetBorderSize(2).Build().Draw();
            SplashKit.DrawText("Level", Color.White, "Modern", 28, 340, 350);
            SplashKit.DrawText(gameModel.Game.CurrentLevel[0].ToString(), Color.White, "Modern", 32, 340, 375);

            SplashKit.DrawText("Next Level", Color.White, "Modern", 28, 340, 425);
            SplashKit.DrawText($"{gameModel.Game.CurrentLevel[1]}/{gameModel.Game.CurrentLevel[3]}", Color.White, "Modern", 32, 340, 450);

            SplashKit.DrawText("Time", Color.White, "Modern", 28, 340, 500);
            SplashKit.DrawText(TickTranslation.TickToString(gameModel.Game.CurrentTick.IngameTimer.Ticks), Color.White, "Modern", 32, 340, 525);
        }
    }
}
