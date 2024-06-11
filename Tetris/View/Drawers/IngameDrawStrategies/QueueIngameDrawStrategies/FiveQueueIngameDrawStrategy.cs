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
    public class FiveQueueIngameDrawStrategy : IQueueIngameDrawStrategy // This class draws 5 queued tetriminos if the game mode is Blitz and 40 Lines
    {
        public void DrawQueue(GameModel gameModel)
        {
            //Draw title of the box
            new RectangleButtonBuilder("Queue").SetPosition(802, 192).SetSize(180, 498).SetBorderSize(2).Build().Draw();
            List<Tetrimino> tetriminos = gameModel.Game.CurrentQueue.GetQueue(5);
            SplashKit.DrawText("Queue", Color.White, "ModernBold", 27, 820, 204);

            int adjustedX;
            int adjustedY;

            //Draw queued tetrimino
            int startY = 245;
            for (int i = 0; i <  tetriminos.Count; i++)
            {
                adjustedX = QueueTetriminoView.AdjustPositionX(tetriminos[i], 800, 180);
                adjustedY = QueueTetriminoView.AdjustPositionY(tetriminos[i], startY);
                tetriminos[i].Draw(adjustedX, adjustedY);
                startY += 90;
            }
        }
    }
}
