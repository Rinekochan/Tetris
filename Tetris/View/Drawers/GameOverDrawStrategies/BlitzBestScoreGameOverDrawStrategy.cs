using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.View.Drawers.GameOverDrawStrategies
{
    public class BlitzBestScoreGameOverDrawStrategy : BestScoreGameOverDrawStrategy // This class provides top 5 Score in Blitz Game Mode Game Over
    {
        public BlitzBestScoreGameOverDrawStrategy() : base(BestScoreManager.Instance.Load(Mode.Blitz))
        {

        }
    }
}
