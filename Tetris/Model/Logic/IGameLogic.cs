using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.GameEventManager;
using Tetris.GameEventManager.GameEvents;
using Tetris.Model.Components.Tetriminos;
using Tetris.Model.Logic.LogicProcessor;

namespace Tetris.Model.Logic
{
    // Interface for game logic, acting as a base for decorators and the core game logic class.
    // Inherits from IEventListener to handle game events.
    public interface IGameLogic : IEventListener 
    {
        public void Run();
        public void Draw(int x, int y);
        // No need to add Update(GameEvent e) here as this interface already inherits from IEventListener.
        public void GetNextTetrimino();
        public Mode GameMode { get; }
        public bool GameOver { get; set; }
        public Tetrimino CurrentTetrimino { get; set;  }
        public Tetrimino? HoldedTetrimino { get; set;  }
        public bool IsSwap {  get; set; }
        public TickProcessor CurrentTick { get; }
        public int[] CurrentLevel { get; }
        public int CurrentScore { get; }
        public QueueProcessor CurrentQueue { get; }

    }
}
