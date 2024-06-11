using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Model;

namespace Tetris.View.Drawers.GameOverDrawStrategies
{
    public class BestTimeGameOverDrawStrategy : BestRecordGameOverDrawStrategy // This class draws top 5 Time in Game Over State
    {
        public BestTimeGameOverDrawStrategy() : base(BestScoreManager.Instance.Load(Mode.FortyLines))
        {

        }

        public override void DrawBestRecord(GameModel gameModel)
        {
            base.DrawBestRecord(gameModel);
            SplashKit.DrawText("Time", Color.White, "Modern", 42, 650, 130);

            Json[] processedBestRecords = new Json[5];
            for (int i = 0; i < BestRecords.Count(); i++)
            {
                if (SplashKit.JsonReadNumberAsInt(BestRecords[i], "Rank") - 1 >= 5) continue; // We only take top 5 scores
                processedBestRecords[SplashKit.JsonReadNumberAsInt(BestRecords[i], "Rank") - 1] = BestRecords[i]; // Sorting based on rank recorded in json file
            }

            int textY = 180;
            for(int i = 0; i < int.Min(BestRecords.Count(), processedBestRecords.Length); i++)
            {
                string time = TickTranslation.TickToString(SplashKit.JsonReadNumberAsInt(processedBestRecords[i], "Time")); 
                SplashKit.DrawText(time, Color.White, "Modern", 32, 650, textY); // Draw time achieved based on the record
                textY += 40;
            }

            string currentTime = $"Your time is: {TickTranslation.TickToString(gameModel.Game.CurrentTick.IngameTimer.Ticks)}";
            SplashKit.DrawText(currentTime, Color.White, "Modern", 24, TextAlignment.HorizontalCenter(currentTime, "Modern", 24), 400);

        }
    }
}
