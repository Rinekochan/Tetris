using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Model.Logic.GameLogicDecorators
{
    public class FortyLinesGameOverDecorator : GameLogicDecorator // This adds forty lines game over to the game ended rule
    {
        public FortyLinesGameOverDecorator(IGameLogic gameLogic) : base(gameLogic)
        {

        }

        public override void Run() // adds forty lines game over to the game ended rules.
        {
            if (CurrentLevel[1] >= 40)
            {
                GameOver = true;
                CurrentTick.Pause();
                return;
            }
            base.Run();
        }
    }
}
