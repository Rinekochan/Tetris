using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Model.Logic.LogicProcessor;

namespace Tetris.Model.Logic.GameLogicDecorators
{
    public class TwoMinutesGameOverDecorator : GameLogicDecorator // This decorator adds two minutes game over to the game ended rules.
    {
        public TwoMinutesGameOverDecorator(IGameLogic gameLogic) : base(gameLogic)
        {

        }

        public override void Run() // adds two minutes game over to the game ended rules.
        {
            if (CurrentTick.IngameTimer.Ticks >= 120000)
            {
                GameOver = true;
                CurrentTick.Pause();
                return;
            }
            base.Run();
        }
    }
}
