using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Model;

namespace Tetris.View.Drawers.IngameDrawStrategies.HoldIngameDrawStrategies
{
    public interface IHoldIngameDrawStrategy // This class provides an interface for drawer to draw hold tetrimino in Ingame state
    {
        public void DrawHold(GameModel gameModel);
    }
}
