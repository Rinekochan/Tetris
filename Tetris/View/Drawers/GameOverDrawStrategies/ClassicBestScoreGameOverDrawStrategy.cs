using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.View.Drawers.GameOverDrawStrategies
{
    public class ClassicBestScoreGameOverDrawStrategy : BestScoreGameOverDrawStrategy // This class provides top 5 Score in Classic Game Mode Game Over
    {
        public ClassicBestScoreGameOverDrawStrategy() : base(BestScoreManager.Instance.Load(Mode.Classic))
        {

        }
    }
}
