using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Model;

namespace Tetris.View.Drawers.IngameDrawStrategies.ExtraIngameDrawStrategies
{
    public interface IExtraIngameDrawStrategy { // This class provides an interface for drawer to draw  extra information in Ingame state
        public void DrawExtra(GameModel gameModel);
    }
}
