using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Model;
using Tetris.Model.Components.ButtonBuilders;

namespace Tetris.View.Drawers
{
    public class MenuDrawer : Drawer // This drawer draws Menu state
    {
        public MenuDrawer() : base(Color.Black, "MenuBackground")
        {

        }

        public override void Draw(GameModel gameModel)
        {
            base.Draw(gameModel);
            Color textColor = Color.RGBColor(49, 60, 83);
            Color secondaryTextColor = Color.RGBColor(123, 43, 43);
            SplashKit.DrawText("CLASSIC", textColor, "ModernBold", 32, TextAlignment.HorizontalCenter("CLASSIC", "ModernBold", 32), 221);
            SplashKit.DrawText("NES", textColor, "ModernBold", 32, TextAlignment.HorizontalCenter("NES", "ModernBold", 32), 283);
            SplashKit.DrawText("40 LINES", textColor, "ModernBold", 32, TextAlignment.HorizontalCenter("40 LINES", "ModernBold", 32), 347);
            SplashKit.DrawText("BLITZ", textColor, "ModernBold", 32, TextAlignment.HorizontalCenter("BLITZ", "ModernBold", 32), 412);
            SplashKit.DrawText("HELP", secondaryTextColor, "RetroBold", 30, TextAlignment.HorizontalCenter("HELP", "RetroBold", 30), 477);
            SplashKit.DrawText("QUIT", secondaryTextColor, "RetroBold", 30, TextAlignment.HorizontalCenter("QUIT", "RetroBold", 30), 532);
        }
    }
}
