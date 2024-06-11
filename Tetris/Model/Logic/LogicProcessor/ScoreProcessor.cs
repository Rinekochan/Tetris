using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Model.Logic.LogicProcessor
{
    public class ScoreProcessor // This class processes score in game logic
    {
        private int _score;

        public ScoreProcessor()
        {
            _score = 0;
        }

        public void Add(int numLineCleared)
        {
            switch (numLineCleared)
            {
                case 1: // Score increases for a single
                    _score += 40;
                    break;
                case 2: // Score increases for a double
                    _score += 100;
                    break;
                case 3: // Score increases for a triple
                    _score += 300;
                    break;
                case 4: // Score increases for a "tetris"
                    _score += 200;
                    break;
            }
        }

        public int Score
        {
            get
            {
                return _score;
            }
        }
    }
}
