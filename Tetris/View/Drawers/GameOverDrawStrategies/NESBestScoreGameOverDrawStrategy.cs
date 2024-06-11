using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.View.Drawers.GameOverDrawStrategies
{
    public class NESBestScoreGameOverDrawStrategy : BestScoreGameOverDrawStrategy // This class provides top 5 Score in NES Game Mode Game Over
    {
        public NESBestScoreGameOverDrawStrategy() : base(BestScoreManager.Instance.Load(Mode.NES))
        {

        }
    }
}
