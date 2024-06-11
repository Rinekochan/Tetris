using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Model.Logic.LogicProcessor.RandomStrategies
{
    // A type of tetrimino only appears once in the queue every 7 turns.
    public class SevenBagRandom : RandomStrategy
    {
        private List<string[]> _permutations;
        public SevenBagRandom() : base()
        {
            _permutations = new List<string[]>();
        }

        // Use recursion to find all permutations
        private List<string[]> GetAllPermutations(string[] ids, List<string> result)
        {
            if (ids.Length == 0)
            {
                return new List<string[]> { result.ToArray() };
            }

            List<string[]> permutations = new List<string[]>();

            for (int i = 0; i < ids.Length; i++)
            {
                string currentId = ids[i];
                List<string> remainingIds = ids.ToList();
                remainingIds.Remove(currentId);

                //Copy old result to new result list to avoid pointer to the same memory.
                List<string> copiedResult = new List<string>();
                copiedResult.AddRange(result);
                copiedResult.Add(currentId);

                permutations.AddRange(GetAllPermutations(remainingIds.ToArray(), copiedResult));
            }

            return permutations;
        }
        public override List<string> Generate() // Generate tetriminos by randomize the permutations
        {
            if (_permutations.Count == 0) _permutations = GetAllPermutations(TetriminoIds, new List<string>());
            Random random = new Random();

            int index = random.Next(_permutations.Count);

            return _permutations[index].ToList();
        }
    }
}
