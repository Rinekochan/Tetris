using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Model.Logic.LogicProcessor
{
    public class LevelProcessor // This class processes Level logic of the game
    {
        private int _level;
        private int _clearedLine;
        // _clearedLine is the number of cleared lines since the start of a level.

        public LevelProcessor(int level)
        {
            _level = level;
            _clearedLine = 0;
        }

        public void Add(int numLineCleared)
        {
            _clearedLine += numLineCleared;
            CheckLevel();
        }

        public int GetNextLevelClearedLine() // the number of lines to clear to reach the next level.
        {
            return int.Min(_level * 10, int.Max(100, (_level * 10 - 50)));
        }
        

        public int NumberOfLineToNextLevel() // Check for number of lines left to reach next level
        {
            return GetNextLevelClearedLine() - _clearedLine;
        }

        public int GetLevelTicks() // get the current level ticks to automatically drop
        {
            int firstLevelTicks = 900;

            if (_level >= 30) return 20;
            else return firstLevelTicks - (_level - 1) * 30;
        }

        private void CheckLevel()
        {
            if (_clearedLine >= GetNextLevelClearedLine())
            {
                _clearedLine -= GetNextLevelClearedLine();
                _level++;
            }
        }

        public int Level
        {
            get
            {
                return _level;
            }
        }

        public int ClearedLine
        {
            get
            {
                return _clearedLine;
            }
        }
    }
}
