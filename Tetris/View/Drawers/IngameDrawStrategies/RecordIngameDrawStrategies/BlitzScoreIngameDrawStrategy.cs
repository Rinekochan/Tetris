using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.View.Drawers.IngameDrawStrategies.RecordIngameDrawStrategies
{
    public class BlitzScoreIngameDrawStrategy : ScoreIngameDrawStrategy // This class provides best score in Blitz game mode in Ingame State
    {
        public BlitzScoreIngameDrawStrategy() : base(BestScoreManager.Instance.LoadBestScore(Mode.Blitz))
        {

        }
    }
}
