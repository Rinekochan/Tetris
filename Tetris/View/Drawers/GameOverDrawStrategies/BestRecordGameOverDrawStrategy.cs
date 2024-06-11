using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Model;

namespace Tetris.View.Drawers.GameOverDrawStrategies
{
    public abstract class BestRecordGameOverDrawStrategy // This class abstracts the top 5 Score/Time Draw in Game Over State
    {
        private List<Json> _bestRecords;
        public BestRecordGameOverDrawStrategy(List<Json> bestRecord)
        {
            _bestRecords = bestRecord;
        }

        public virtual void DrawBestRecord(GameModel gameModel)
        {
            SplashKit.DrawText("No.", Color.White, "Modern", 42, 150, 130);
            SplashKit.DrawText("1", Color.White, "Modern", 36, 160, 180);
            SplashKit.DrawText("2", Color.White, "Modern", 36, 160, 220);
            SplashKit.DrawText("3", Color.White, "Modern", 36, 160, 260);
            SplashKit.DrawText("4", Color.White, "Modern", 36, 160, 300);
            SplashKit.DrawText("5", Color.White, "Modern", 36, 160, 340);
            SplashKit.DrawText("Name", Color.White, "Modern", 42, 250, 130);
            SplashKit.DrawText("Level", Color.White, "Modern", 42, 1000, 130);

            Json[] processedBestRecords = new Json[5];
            for (int i = 0; i < BestRecords.Count(); i++)
            {
                if(SplashKit.JsonReadNumberAsInt(BestRecords[i], "Rank") - 1 >= 5) continue; // We only take top 5 records
                processedBestRecords[SplashKit.JsonReadNumberAsInt(BestRecords[i], "Rank") - 1] = BestRecords[i]; // Sorting based on rank recorded in json file
            }

            int textY = 180;
            for (int i = 0; i < 5; i++)
            {
                if (i >= BestRecords.Count())
                {
                    SplashKit.DrawText("None", Color.White, "Modern", 32, 250, textY); // Draw none if there's no score at that rank
                    SplashKit.DrawText("None", Color.White, "Modern", 32, 650, textY); // Draw none if there's no score at that rank
                    SplashKit.DrawText("None", Color.White, "Modern", 32, 1000, textY); // Draw none if there's no score at that rank
                }
                else
                {
                    string name = SplashKit.JsonReadString(processedBestRecords[i], "Player");
                    SplashKit.DrawText(name, Color.White, "Modern", 32, 250, textY); // Draw Player name
                    string level = SplashKit.JsonReadNumberAsInt(processedBestRecords[i], "Level").ToString();
                    SplashKit.DrawText(level, Color.White, "Modern", 32, 1000, textY); // Draw level achieved based on the record
                }
                textY += 40;
            }
        }

        public List<Json> BestRecords
        {
            get
            {
                return _bestRecords;
            }
        }
    }
}
