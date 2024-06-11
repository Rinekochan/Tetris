using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.View.Drawers.GameOverDrawStrategies;

namespace Tetris.View.StaticFactories
{
    public static class BestRecordGameOverDrawFactory
    {
        public static BestRecordGameOverDrawStrategy Create(Mode mode) // seperates/encapsulates the creation process of BestRecordGameOverDrawStrategy for GameOverDrawer
        {
            switch (mode)
            {
                case Mode.Classic: // If gamemode is Classic, GameOverDrawer will use ClassicBestScoreGameOverDraw strategy
                    return new ClassicBestScoreGameOverDrawStrategy();
                case Mode.NES: // If gamemode is NES, GameOverDrawer will use NESBestScoreGameOverDraw strategy
                    return new NESBestScoreGameOverDrawStrategy();
                case Mode.Blitz: // If gamemode is Blitz, GameOverDrawer will use BlitzBestScoreGameOverDraw strategy
                    return new BlitzBestScoreGameOverDrawStrategy();
                case Mode.FortyLines: // If gamemode is FortyLines, GameOverDrawer will use BestTimeGameOverDraw strategy
                    return new BestTimeGameOverDrawStrategy();
                default:
                    throw new Exception($"I don't know what mode is {mode} to create GameOverDrawStrategy");
            }
        }
    }
}
