using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.View.Drawers.IngameDrawStrategies.RecordIngameDrawStrategies
{
    public class ClassicScoreIngameDrawStrategy : ScoreIngameDrawStrategy // This class provides best score in Blitz game mode in Classic State
    {
        public ClassicScoreIngameDrawStrategy() : base(BestScoreManager.Instance.LoadBestScore(Mode.Classic))
        {

        }
    }
}
