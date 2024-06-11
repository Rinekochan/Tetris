using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using SplashKitSDK;
using Tetris.GameEventManager;
using Tetris.GameEventManager.GameEvents;
using Tetris.Model.Components;
using Tetris.Model.Components.Tetriminos;
using Tetris.Model.Logic.LogicProcessor;

namespace Tetris.Model.Logic
{
    public class GameLogic : IGameLogic
    {
        private Grid _grid;
        private EventManager _eventManager;
        private Tetrimino _currentTetrimino;
        private Tetrimino? _holdedTetrimino;
        private bool _isSwap; // Player can only swap one time before the tetrimino is placed
        private ScoreProcessor _currentScore;
        private LevelProcessor _currentLevel;
        private QueueProcessor _currentQueue;
        private TickProcessor _currentTick;
        private bool _gameOver, _gameLosed; // game losed is to checked if the player is losed, gameOver will true if gameLosed is true or with another conditions (in decorators)
        private Mode _gameMode;

        public GameLogic(Mode gameMode, EventManager eventManager, Grid grid, ScoreProcessor currentScore, LevelProcessor currentLevel, QueueProcessor currentQueue, TickProcessor tickProcessor)
        {
            _gameMode = gameMode;
            _eventManager = eventManager;
            _grid = grid;
            _currentScore = currentScore;
            _currentLevel = currentLevel;
            _currentQueue = currentQueue;
            _currentTick = tickProcessor;
            _currentTetrimino = _currentQueue.GetTetrimino();
            _holdedTetrimino = null; // The holded tetrimino can holds an another tetrimino, or holds nothing
            _isSwap = false;
            _gameOver = false;
            _gameLosed = false;
        }

        public void Run() // The game automatically move the tetrimino down overtime
        {
            if (_gameLosed)
            {
                _currentTick.Pause();
                _gameOver = true;
                return;
            }

            if (_currentTick.LastDropTimer.Ticks >= _currentLevel.GetLevelTicks())
            {
                MoveDownWithLock();
                _currentTick.LastDropTimer.Reset();
            }
        }

        public void Draw(int x, int y) // This method draws the current grid and current tetrimino.
        {
            _grid.Draw(x, y);
            _currentTetrimino.Draw(x, y);
        }

        public void Update(GameEvent e)
        {
            Enum.TryParse(e.GetMessage()[0], out Event eventType);
            switch (eventType)
            {
                case Event.TetriminoInteraction:
                    TetriminoInteractionEventHandler(e.GetMessage()[1]);
                    break;
            }
        }

        // Check if the game has end based on game mode

        public void GetNextTetrimino() // Get Next Tetrimino from the queue processor
        {
            _currentTetrimino = _currentQueue.GetTetrimino();
            _currentTick.LastDropTimer.Reset();
        }

        private void TetriminoInteractionEventHandler(string direction) // This method will handles Move Event
        {
            switch (direction)
            {
                case "Left":
                    MoveLeft();
                    break;
                case "Right":
                    MoveRight();
                    break;
                case "Down":
                    MoveDownWithLock();
                    break;
                case "Hard":
                    HardDrop();
                    break;
                case "CW":
                    RotateCW();
                    break;
                case "CCW":
                    RotateCCW();
                    break;
            }        
        }

        private bool TetriminoFits() // This method will check if the tetrimino is fitted after doing something (move, rotate, place)
        {
            foreach (Cell cell in _currentTetrimino.GetCellPosition())
            {
                if (!_grid.IsValid(cell.Position)) return false;
            }
            return true;
        }

        private void MoveLeft() // Move Tetrimino to left, if not fit undo
        {
            _currentTetrimino.Move(0, -1);

            if (!TetriminoFits()) _currentTetrimino.Move(0, 1);
        }

        private void MoveRight() // Move Tetrimino to right, if not fit undo
        {
            _currentTetrimino.Move(0, 1);

            if (!TetriminoFits()) _currentTetrimino.Move(0, -1);
        }

        private void MoveDown() // This will move tetrimino down but doesn't check if it fits or not (use for Hard Drop)
        {
            _currentTetrimino.Move(1, 0);
        }
        private void MoveDownWithLock() // This will move tetrimino down while also checking if it fits or not
        {
            MoveDown();
            if (!TetriminoFits())
            {
                _currentTetrimino.Move(-1, 0);
                LockTetrimino();
            }
        }
        //Rotate clock-wise
        private void RotateCW()
        {
            _currentTetrimino.Rotate(true);

            if (!TetriminoFits()) _currentTetrimino.Rotate(false);
        }

        //Rotate counter clock-wise
        private void RotateCCW()
        {
            _currentTetrimino.Rotate(false);

            if (!TetriminoFits()) _currentTetrimino.Rotate(true);
        }

        // Place tetriminos to the lowest position possible 
        private void HardDrop()
        {
            while (TetriminoFits())
            {
                MoveDown();
            }

            if (!TetriminoFits())
            {
                _currentTetrimino.Move(-1, 0);
                LockTetrimino();
            }
        }

        private void ClearProcessing() // This method processes and gets number of cleared lines.
        {
            int lineCleared = _grid.ClearFullRows();
            if (lineCleared > 0)
            {
                _currentScore.Add(lineCleared);
                _currentLevel.Add(lineCleared);
                _eventManager.Post(new GameEvent(Event.ClearLine));
            }
            else
            {
                _eventManager.Post(new GameEvent(Event.PlaceTetrimino));
            }
        }

        private void LockTetrimino() // This method will place and lock tetrimino
        {
            foreach (Cell cell in _currentTetrimino.GetCellPosition())
            {
                _grid.Matrix[cell.Position.Row, cell.Position.Column] = new Cell(cell.Color, cell.Position, true);
            }
            ClearProcessing();
            GetNextTetrimino();
            _isSwap = false; // The player can swap again
            _gameLosed = !TetriminoFits(); // If the tetrimino is not fitted right after it is created, the game losed is true (which leads to game over)
        }

        public Mode GameMode
        {
            get
            {
                return _gameMode;
            }
        }


        public bool GameOver
        {
            get
            {
                return _gameOver;

            }
            set
            {
                _gameOver = value;
            }
        }

        public Tetrimino CurrentTetrimino
        {
            get
            {
                return _currentTetrimino;
            }
            set
            {
                _currentTetrimino = value;
            }
        }

        public Tetrimino? HoldedTetrimino
        {
            get
            {
                return _holdedTetrimino;
            }
            set
            {
                _holdedTetrimino = value;
            }
        }

        public bool IsSwap
        {
            get
            {
                return _isSwap;
            }
            set
            {
                _isSwap = value;
            }
        }

        public TickProcessor CurrentTick
        {
            get
            {
                return _currentTick;
            }
        }

        public int[] CurrentLevel
        {
            get
            {
                return [_currentLevel.Level, _currentLevel.ClearedLine, _currentLevel.NumberOfLineToNextLevel(), _currentLevel.GetNextLevelClearedLine()];
            }
        }

        public int CurrentScore
        {
            get
            {
                return _currentScore.Score;
            }
        }

        public QueueProcessor CurrentQueue
        {
            get
            {
                return _currentQueue;
            }
        }
    }
}
