using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Model;

namespace Tetris.View.Drawers.IngameDrawStrategies.HoldIngameDrawStrategies
{
    public class HasHoldIngameDrawStrategy : IHoldIngameDrawStrategy // This class draws hold tetrimino if the game mode rules allows to hold
    {
        public void DrawHold(GameModel gameModel)
        {
            SplashKit.DrawText("Hold", Color.White, "ModernBold", 27, 340, 48);
            int adjustedX;
            int adjustedY;
            if(gameModel.Game.HoldedTetrimino != null)
            {
                adjustedX = QueueTetriminoView.AdjustPositionX(gameModel.Game.HoldedTetrimino, 320, 180);
                adjustedY = QueueTetriminoView.AdjustPositionY(gameModel.Game.HoldedTetrimino, 90);
                if (gameModel.Game.HoldedTetrimino.ID == "I") adjustedY -= 15;
                gameModel.Game.HoldedTetrimino.Draw(adjustedX, adjustedY);
            }
        }
    }
}
