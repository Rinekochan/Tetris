using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Tetris.Model;
using Tetris.View.Drawers.GameOverDrawStrategies;

namespace Tetris.View.Drawers
{
    public class GameOverDrawer : Drawer // This drawer draws Game Over state
    {
        private BestRecordGameOverDrawStrategy _bestRecordDraw;
        public GameOverDrawer(BestRecordGameOverDrawStrategy bestRecordDraw) : base(Color.Black)
        {
            _bestRecordDraw = bestRecordDraw;
        }

        public override void Draw(GameModel gameModel)
        {
            base.Draw(gameModel);
            _bestRecordDraw.DrawBestRecord(gameModel);
            SplashKit.DrawText("GAME OVER", Color.White, "Retro", 120, TextAlignment.HorizontalCenter("GAME OVER", "Retro", 120), 10);
            SplashKit.DrawText("Name", Color.White, "Retro", 36, 340, 470);
            if (SplashKit.ReadingText())
            {
                SplashKit.DrawCollectedText(Color.White, SplashKit.FontNamed("Modern"), 27, SplashKit.OptionDefaults());
            }
            else // If the player finish writing text
            {
                string name;
                // Get the name from the text input
                name = SplashKit.TextInput();
                SplashKit.DrawText(name, Color.White, "Modern", 27, 500, 480);
            }

            string warning = "(It won't be saved if you lose the game in 40 Lines)";
            SplashKit.DrawText(warning, Color.White, "Modern", 20, TextAlignment.HorizontalCenter(warning, "Modern", 20), 430);

            SplashKit.DrawText("SAVE", Color.White, "Retro", 36, 840, 470);
            SplashKit.DrawText("RESTART", Color.White, "Retro", 56, TextAlignment.HorizontalCenter("RESTART", "Retro", 56), 550);
            SplashKit.DrawText("MENU", Color.White, "Retro", 56, TextAlignment.HorizontalCenter("MENU", "Retro", 56), 630);
        }
    }
}
