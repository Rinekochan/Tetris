using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Model;

namespace Tetris.View.Drawers.IngameDrawStrategies.RecordIngameDrawStrategies
{
    public class ScoreIngameDrawStrategy : RecordIngameDrawStrategy // This class abstracts the current score and best score in Ingame state
    {
        public ScoreIngameDrawStrategy(int bestScore) : base(bestScore)
        {

        }

        public override void DrawRecord(GameModel gameModel)
        {
            string score = gameModel.Game.CurrentScore.ToString();
            string bestScore = BestRecord.ToString();

            while (score.Length < 7) // Padding score to get 7 digit
            {
                score = "0" + score;
            }

            while (bestScore.Length < 7)
            {
                bestScore = "0" + bestScore;
            }


            SplashKit.DrawText("Best Score", Color.White, "Modern", 27, 820, 50);
            SplashKit.DrawText(bestScore, Color.White, "Modern", 36, 820, 75);

            SplashKit.DrawText("Score", Color.White, "Modern", 27, 820, 120);
            SplashKit.DrawText(score, Color.White, "Modern", 36, 820, 145);
        }
    }
}
