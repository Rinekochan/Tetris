using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Model;

namespace Tetris.View.Drawers.IngameDrawStrategies.RecordIngameDrawStrategies
{
    public abstract class RecordIngameDrawStrategy // This class abstracts the current score/time and best score/time of each game mode in Ingame state
    {
        private int _bestRecord;

        public RecordIngameDrawStrategy(int bestRecord)
        {
            _bestRecord = bestRecord;
        }
        public abstract void DrawRecord(GameModel gameModel);

        public int BestRecord
        {
            get
            {
                return _bestRecord;
            }
        }
    }
}
