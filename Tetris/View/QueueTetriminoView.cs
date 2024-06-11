using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Model.Components;
using Tetris.Model.Components.Tetriminos;

namespace Tetris.View
{
    public static class QueueTetriminoView // this static class adjust queue tetrimino position
    {
        public static int AdjustPositionX(Tetrimino tetrimino, int boxX, int boxSize) // This center the queue tetrimino horizally in a box
        {
            int currentX = boxX + boxSize / 2 - tetrimino.Position.Column * 30 * 3 / 2 ;
            switch (tetrimino.ID)
            {
                case "O":
                    return currentX + 30;
                case "I":
                    return currentX - 15;
                default:
                    return currentX;
            }
        }

        public static int AdjustPositionY(Tetrimino tetrimino, int Y) // This returns the normal Y coord
        {
            if (tetrimino.ID == "I") return Y - tetrimino.Position.Row * 30 - 15;
            return Y - tetrimino.Position.Row * 30;
        }
    }
}
