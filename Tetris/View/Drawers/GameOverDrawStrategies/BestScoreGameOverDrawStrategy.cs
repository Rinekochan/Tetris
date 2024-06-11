using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Model;

namespace Tetris.View.Drawers.GameOverDrawStrategies
{
    public abstract class BestScoreGameOverDrawStrategy : BestRecordGameOverDrawStrategy // This class draws top 5 Score in Game Over State
    {
        public BestScoreGameOverDrawStrategy(List<Json> bestScores) : base(bestScores)
        {

        }

        public override void DrawBestRecord(GameModel gameModel)
        {
            base.DrawBestRecord(gameModel);
            SplashKit.DrawText("Score", Color.White, "Modern", 42, 650, 130);

            Json[] processedBestRecords = new Json[5];
            for (int i = 0; i < BestRecords.Count(); i++)
            {
                if (SplashKit.JsonReadNumberAsInt(BestRecords[i], "Rank") - 1 >= 5) continue; // We only take top 5 scores
                processedBestRecords[SplashKit.JsonReadNumberAsInt(BestRecords[i], "Rank") - 1] = BestRecords[i]; // Sorting based on rank recorded in json file
            }

            int textY = 180;
            for (int i = 0; i < int.Min(BestRecords.Count(), processedBestRecords.Length); i++)
            {
                string score = SplashKit.JsonReadNumberAsInt(processedBestRecords[i], "Score").ToString();
                SplashKit.DrawText(score, Color.White, "Modern", 32, 650, textY); // Draw score achieved based on the record
                textY += 40;
            }

            string currentScore = $"Your score is: {gameModel.Game.CurrentScore}";
            SplashKit.DrawText(currentScore, Color.White, "Modern", 24, TextAlignment.HorizontalCenter(currentScore, "Modern", 24), 400);
        }
    }
}
