using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Model;
using Tetris.Model.Components.Tetriminos;

namespace Tetris.View.Drawers.IngameDrawStrategies.QueueIngameDrawStrategies
{
    public interface IQueueIngameDrawStrategy // This class provides an interface for drawer to draw Queue tetrimino in Ingame state
    {
        public void DrawQueue(GameModel gameModel);
    }
}
