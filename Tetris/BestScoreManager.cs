using SplashKitSDK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Tetris.Model.Logic;
using Tetris.Model.States;

namespace Tetris
{
    public sealed class BestScoreManager // Thread-safety singleton, this class provides global instance to save/load scores from json file in Tetris/Resources/json/BestScore.json
    {
        private static BestScoreManager instance = null;
        private static readonly object padlock = new object();
        private string _fileName;
        private BestScoreManager()
        {
            _fileName = "BestScore.json";
        }

        public static BestScoreManager Instance
        {
            get
            {
                lock (padlock) // This will lock the logic inside and only unlock when the logic has been executed completely.
                {
                    if (instance == null)
                    {
                        instance = new BestScoreManager();
                    }
                    return instance;
                }
            }
        }
        private void CreateDefaultJson() // it will create a default json file if BestRecord.json doesn't exist
        {
            Json file = SplashKit.CreateJson();

            Json defaultRecord = SplashKit.CreateJson();
            defaultRecord = SetRecord(1, "default", 0, 0, int.MaxValue); // This is default record (if the player plays more it will automatically disappears from top 5)
            List<Json> defaultMode = new List<Json> { defaultRecord };

            file.AddArray("Classic", defaultMode);
            file.AddArray("NES", defaultMode);
            file.AddArray("Blitz", defaultMode);
            file.AddArray("FortyLines", defaultMode);

            SplashKit.JsonToFile(file, _fileName);
        }

        private Json SetRecord(int rank, string playerName, int score, int level, int time)
        {
            Json record = SplashKit.CreateJson();
            SplashKit.JsonSetNumber(record, "Rank", rank);
            SplashKit.JsonSetString(record, "Player", playerName);
            SplashKit.JsonSetNumber(record, "Score", score);
            SplashKit.JsonSetNumber(record, "Level", level);
            SplashKit.JsonSetNumber(record, "Time", time);
            return record;
        }

        private void SortScores(Mode mode, List<Json> scoresArray, Json score) // Sort scores in arrays
        {
            scoresArray.Add(score);
            if (mode == Mode.FortyLines) scoresArray = scoresArray.OrderBy(score => score.ReadNumber("Time")).ToList(); // Sort ascending based on time in forty-lines
            else scoresArray = scoresArray.OrderByDescending(score => score.ReadNumber("Score")).ToList(); // Sort descending based on score at other modes.

            for (int i = 0; i < scoresArray.Count; i++) // Rewrites the rank of json object
            {
                SplashKit.JsonSetNumber(scoresArray[i], "Rank", i + 1);
            }
        }

        public void CheckExistedJson()
        {
            if (!File.Exists($"{SplashKit.PathToResources()}\\json\\{_fileName}"))
            {
                //Console.WriteLine($"Path {_fileName} does not exist");
                File.Create(_fileName).Dispose(); // Create a new file
                CreateDefaultJson(); // Write default json into the new file
            }
        }

        public void Save(IGameLogic gameLogic, string playerName) // This will rewrites the Json file when save a new score (a new score is not saved if it's not in top 5)
        {
            CheckExistedJson();
            Json fileWriter = SplashKit.JsonFromFile(_fileName);

            List<Json> scores = new List<Json>();

            fileWriter.ReadArray(gameLogic.GameMode.ToString(), ref scores);

            Json score = SetRecord(6, playerName, gameLogic.CurrentScore, gameLogic.CurrentLevel[0], (int)gameLogic.CurrentTick.IngameTimer.Ticks);
            SortScores(gameLogic.GameMode, scores, score);

            SplashKit.JsonSetArray(fileWriter, gameLogic.GameMode.ToString(), scores); // SplashKit add new record instead of rewrite the whole array so we can't technically sort :(
            SplashKit.JsonToFile(fileWriter, _fileName);
        }

        public Json LoadAll() // This load all objects available in the file
        {
            CheckExistedJson();
            Json fileReader = SplashKit.JsonFromFile(_fileName);
            return fileReader;
        }

        public List<Json> Load(Mode mode) // Load object based on game mode
        {
            CheckExistedJson();
            Json fileReader = SplashKit.JsonFromFile(_fileName);
            List<Json> scores = new List<Json>();

            fileReader.ReadArray(mode.ToString(), ref scores);
            return scores;
        }

        public int LoadBestScore(Mode mode)
        {
            List<Json> bestRecords = Load(mode);
            Json bestRecord = bestRecords[0];
            foreach(Json record in bestRecords)
            {
                if (SplashKit.JsonReadNumberAsInt(record, "Rank") == 1) // Choosing the best record
                {
                    bestRecord = record; break;
                }
            }
            int bestScore = SplashKit.JsonReadNumberAsInt(bestRecord, "Score");
            return bestScore;
        }

        public int LoadBestTime(Mode mode)
        {
            List<Json> bestRecords = Load(mode);
            Json bestRecord = bestRecords[0];
            foreach (Json record in bestRecords)
            {
                if (SplashKit.JsonReadNumberAsInt(record, "Rank") == 1) // Choosing the best record
                {
                    bestRecord = record; break;
                }
            }
            int bestScore = SplashKit.JsonReadNumberAsInt(bestRecord, "Time");
            if (bestScore == int.MaxValue) return 0; // If the bestTime we are looking for is INT_MAX, it's default time so we are not going to use it to display
            return bestScore;
        }
    }
}
