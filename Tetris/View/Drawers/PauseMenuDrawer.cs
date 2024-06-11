using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Model;

namespace Tetris.View.Drawers
{
    public class PauseMenuDrawer : Drawer // This drawer draws Pause Menu state
    {
        public PauseMenuDrawer() : base(Color.Black)
        {

        }

        public override void Draw(GameModel gameModel)
        {
            base.Draw(gameModel);
            SplashKit.DrawText("PAUSED", Color.White, "Retro", 120, TextAlignment.HorizontalCenter("PAUSED", "Retro", 120), 100);
            SplashKit.DrawText("CONTINUE", Color.White, "Retro", 56, TextAlignment.HorizontalCenter("CONTINUE", "Retro", 56), 280);
            SplashKit.DrawText("RESTART", Color.White, "Retro", 56, TextAlignment.HorizontalCenter("RESTART", "Retro", 56), 380);
            SplashKit.DrawText("MENU", Color.White, "Retro", 56, TextAlignment.HorizontalCenter("MENU", "Retro", 56), 480);
        }
    }
}
