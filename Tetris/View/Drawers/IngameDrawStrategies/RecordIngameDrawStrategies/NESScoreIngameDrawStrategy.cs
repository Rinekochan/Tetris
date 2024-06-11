using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.View.Drawers.IngameDrawStrategies.RecordIngameDrawStrategies
{
    public class NESScoreIngameDrawStrategy : ScoreIngameDrawStrategy // This class provides best score in Blitz game mode in NES State
    {
        public NESScoreIngameDrawStrategy() : base(BestScoreManager.Instance.LoadBestScore(Mode.NES))
        {

        }
    }
}
