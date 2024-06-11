using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.GameEventManager.GameEvents;
using Tetris.Model.Components.Tetriminos;
using Tetris.Model.Logic.LogicProcessor;

namespace Tetris.Model.Logic.GameLogicDecorators
{
    // This class is base decorator for GameLogic, so we can add any decorators to the GameLogic based on the gamemode
    // The purpose is that some game modes can have the same additional rules (like be able to hold tetrimino) leads to duplicate code, and redundant subclasses.
    public abstract class GameLogicDecorator : IGameLogic 
    {
        private IGameLogic _gameLogic;
        public GameLogicDecorator(IGameLogic gameLogic)
        {
            _gameLogic = gameLogic;
        }

        public virtual void Run()
        {
            _gameLogic.Run();
        }

        public virtual void Draw(int x, int y)
        {
            _gameLogic.Draw(x, y);
        }

        public virtual void Update(GameEvent e)
        {
            _gameLogic.Update(e);
        }

        public virtual void GetNextTetrimino()
        {
            _gameLogic.GetNextTetrimino();
        }

        public Mode GameMode
        {
            get
            {
                return _gameLogic.GameMode;
            }
        }


        public bool GameOver
        {
            get
            {
                return _gameLogic.GameOver;

            }
            set
            {
                _gameLogic.GameOver = value;
            }
        }

        public Tetrimino CurrentTetrimino
        {
            get
            {
                return _gameLogic.CurrentTetrimino;
            }
            set
            {
                _gameLogic.CurrentTetrimino = value;
            }
        }

        public Tetrimino? HoldedTetrimino
        {
            get
            {
                return _gameLogic.HoldedTetrimino;
            }
            set
            {
                _gameLogic.HoldedTetrimino = value;
            }
        }

        public bool IsSwap
        {
            get
            {
                return _gameLogic.IsSwap;
            }
            set
            {
                _gameLogic.IsSwap = value;
            }
        }

        public TickProcessor CurrentTick
        {
            get
            {
                return _gameLogic.CurrentTick;
            }
        }

        public int[] CurrentLevel
        {
            get
            {
                return _gameLogic.CurrentLevel;
            }
        }

        public int CurrentScore
        {
            get
            {
                return _gameLogic.CurrentScore;
            }
        }

        public QueueProcessor CurrentQueue
        {
            get
            {
                return _gameLogic.CurrentQueue;
            }
        }
    }
}
