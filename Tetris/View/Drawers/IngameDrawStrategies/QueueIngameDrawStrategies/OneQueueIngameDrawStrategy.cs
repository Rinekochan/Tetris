using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Model;
using Tetris.Model.Components.ButtonBuilders;
using Tetris.Model.Components.Tetriminos;

namespace Tetris.View.Drawers.IngameDrawStrategies.QueueIngameDrawStrategies
{
    public class OneQueueIngameDrawStrategy : IQueueIngameDrawStrategy // This class draws 1 queued tetriminos if the game mode is Classic and NES
    {
        public void DrawQueue(GameModel gameModel)
        {
            //Draw title of the box
            new RectangleButtonBuilder("Queue").SetPosition(802, 192).SetSize(180, 170).SetBorderSize(2).Build().Draw();
            List<Tetrimino> tetriminos = gameModel.Game.CurrentQueue.GetQueue(1);
            SplashKit.DrawText("Queue", Color.White, "ModernBold", 27, 820, 204);
            //Draw queued tetrimino
            int adjustedX = QueueTetriminoView.AdjustPositionX(tetriminos[0], 800, 180);
            int adjustedY = QueueTetriminoView.AdjustPositionY(tetriminos[0], 250);

            tetriminos[0].Draw(adjustedX, adjustedY);
        }
    }
}
