using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Model.Components.Tetriminos;
using Tetris.Model.Factories;
using Tetris.Model.Logic.LogicProcessor.RandomStrategies;

namespace Tetris.Model.Logic.LogicProcessor
{
    public class QueueProcessor // This class processes the tetrimino queue in game logic
    {
        private List<string> _queue;
        private RandomStrategy _randomStrategy;

        public QueueProcessor(RandomStrategy randomStrategy)
        {
            _queue = new List<string>();
            _randomStrategy = randomStrategy;
        }

        public Tetrimino GetTetrimino() // Get the next tetrimino in the queue
        {
            if (IsGenerateNeeded())
            {
                _queue.AddRange(_randomStrategy.Generate());
            }

            Tetrimino nextTetrimino = TetriminoFactory.Create(_queue[0]);

            _queue.RemoveAt(0);

            return nextTetrimino;
        }

        public List<Tetrimino> GetQueue(int amount) // Get tetrimino queue based on the amount
        {
            List<Tetrimino> result = new List<Tetrimino>();

            for (int i = 0; i < amount; i++)
            {
                result.Add(TetriminoFactory.Create(_queue[i]));
            }

            return result;
        }

        private bool IsGenerateNeeded() // We display 5 queued tetrimino in GameView
        {
            return _queue.Count < 7;
        }
    }
}
