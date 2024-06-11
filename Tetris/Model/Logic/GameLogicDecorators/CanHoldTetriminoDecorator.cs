using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.GameEventManager.GameEvents;
using Tetris.Model.Components.Tetriminos;
using Tetris.Model.Factories;

namespace Tetris.Model.Logic.GameLogicDecorators
{
    public class CanHoldTetriminoDecorator : GameLogicDecorator // This decorator allows player to hold
    {
        public CanHoldTetriminoDecorator(IGameLogic gameLogic) : base(gameLogic)
        {

        }

        public override void Update(GameEvent e) // This decorator extends Update method to hold tetrimino
        {
            Enum.TryParse(e.GetMessage()[0], out Event eventType);
            switch (eventType)
            {
                case Event.TetriminoInteraction:
                    if (e.GetMessage()[1] == "Hold") HoldTetrimino();
                    break;
            }
            base.Update(e);
        }

        private void HoldTetrimino()
        {
            if (IsSwap) return; // The player can only swap/hold one time before the tetrimino is placed
            IsSwap = true;
            if (HoldedTetrimino == null) // If there is not holded tetrimino, hold the current tetrimino and get the next one
            {
                HoldedTetrimino = TetriminoFactory.Create(CurrentTetrimino.ID);
                GetNextTetrimino();
            }
            else // If there is already a holded tetrimino, swap the holded tetrimino with the current tetrimino
            {
                Tetrimino tempTetrimino = HoldedTetrimino;
                HoldedTetrimino = TetriminoFactory.Create(CurrentTetrimino.ID);
                CurrentTetrimino = tempTetrimino;
            }
        }
    }
}
