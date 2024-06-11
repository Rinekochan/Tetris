using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Model.Logic.LogicProcessor.RandomStrategies
{
    // Abstract class representing the strategy for randomizing Tetrimino generation.
    public abstract class RandomStrategy
    {
        private readonly string[] _tetriminoIds;
        public RandomStrategy()
        {
            _tetriminoIds = new string[]
           {
                "I",
                "J",
                "L",
                "O",
                "S",
                "T",
                "Z"
           };
        }
        public abstract List<string> Generate();

        public string[] TetriminoIds
        {
            get
            {
                return _tetriminoIds;
            }
        }
    }
}
