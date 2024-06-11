using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Model;

namespace Tetris.View.Drawers.IngameDrawStrategies.RecordIngameDrawStrategies
{
    internal class TimeIngameDrawStrategy : RecordIngameDrawStrategy // This class abstracts the current time and fastest time in Ingame state
    {
        public TimeIngameDrawStrategy() : base(BestScoreManager.Instance.LoadBestTime(Mode.FortyLines))
        {

        }

        public override void DrawRecord(GameModel gameModel)
        {
            string time = TickTranslation.TickToString(gameModel.Game.CurrentTick.IngameTimer.Ticks);
            string bestTime = TickTranslation.TickToString(BestRecord);


            SplashKit.DrawText("Best Time", Color.White, "Modern", 27, 820, 50);
            SplashKit.DrawText(bestTime, Color.White, "Modern", 36, 820, 75);

            SplashKit.DrawText("Time", Color.White, "Modern", 27, 820, 120);
            SplashKit.DrawText(time, Color.White, "Modern", 36, 820, 145);
        }
    }
}
