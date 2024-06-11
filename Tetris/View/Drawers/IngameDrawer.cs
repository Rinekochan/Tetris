using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;
using Tetris.Model;
using Tetris.View.Drawers.IngameDrawStrategies.ExtraIngameDrawStrategies;
using Tetris.View.Drawers.IngameDrawStrategies.HoldIngameDrawStrategies;
using Tetris.View.Drawers.IngameDrawStrategies.QueueIngameDrawStrategies;
using Tetris.View.Drawers.IngameDrawStrategies.RecordIngameDrawStrategies;

namespace Tetris.View.Drawers
{
    public class IngameDrawer : Drawer // This drawer draws Ingame state
    {
        private RecordIngameDrawStrategy _recordDraw;
        private IQueueIngameDrawStrategy _queueDraw;
        private IHoldIngameDrawStrategy _holdDraw;
        private IExtraIngameDrawStrategy _extraDraw;

        public IngameDrawer(RecordIngameDrawStrategy recordDraw, IQueueIngameDrawStrategy queueDraw, IHoldIngameDrawStrategy holdDraw, IExtraIngameDrawStrategy extraDraw) : base(Color.Black, "SpaceBackground")
        {
            _recordDraw = recordDraw;
            _queueDraw = queueDraw;
            _holdDraw = holdDraw;
            _extraDraw = extraDraw;
        }

        public override void Draw(GameModel gameModel)
        {
            base.Draw(gameModel);
            // Draw grid and current tetrimino
            gameModel.Game.Draw(500, 30);
            // Draw current game mode
            string currentGameMode = gameModel.Game.GameMode.ToString();
            if (currentGameMode == "FortyLines") currentGameMode = "40 Lines"; // Change this game mode name for easier to read

            SplashKit.DrawText(currentGameMode.ToUpper(), Color.White, "Modern", 32, TextAlignment.HorizontalCenter(currentGameMode.ToUpper(), "Modern", 32, 320, 180), TextAlignment.VerticalCenter(currentGameMode.ToUpper(), "Modern", 32, 182, 88));
            // Draw assigned strategies for each game mode
            _recordDraw.DrawRecord(gameModel);
            _queueDraw.DrawQueue(gameModel);
            _holdDraw.DrawHold(gameModel);
            _extraDraw.DrawExtra(gameModel);
        }
    }
}
