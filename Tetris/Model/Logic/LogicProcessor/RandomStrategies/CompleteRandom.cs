using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Model.Logic.LogicProcessor.RandomStrategies
{
    // A type of tetrimino is generated randomly, it's possible that 5 consecutive same blocks are generated.
    public class CompleteRandom : RandomStrategy
    {
        public CompleteRandom() : base()
        {
        }

        public override List<string> Generate() // Generate completely random tetriminos
        {
            List<string> queue = new List<string>();
            Random random = new Random();

            for (int amount = 0; amount < 7; amount++)
            {
                queue.Add(TetriminoIds[random.Next(TetriminoIds.Length)]);
            }

            return queue;
        }
    }
}
