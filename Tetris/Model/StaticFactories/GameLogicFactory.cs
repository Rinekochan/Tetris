using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.GameEventManager;
using Tetris.Model.Components;
using Tetris.Model.Logic;
using Tetris.Model.Logic.GameLogicDecorators;
using Tetris.Model.Logic.LogicProcessor;

namespace Tetris.Model.Factories
{
    public static class GameLogicFactory // This class encapsulates/separates the creation process of Game Logic from logic 
    {
        public static IGameLogic Create(Mode mode, EventManager eventManager)
        {
            Grid grid = GridFactory.Create(mode); // Delegate QueueProcessor creation to Factory class
            ScoreProcessor scoreProcessor = ScoreProcessorFactory.Create(); // Delegate ScoreProcessor creation to Factory class
            LevelProcessor levelProcessor = LevelProcessorFactory.Create(mode); // Delegate LevelProcessor creation to Factory class
            QueueProcessor queueProcessor = QueueProcessorFactory.Create(mode); // Delegate QueueProcessor creation to Factory class
            TickProcessor tickProcessor = TickProcessorFactory.Create(); // Delegate TickProcessor creation to Factory class

            GameLogic gameLogic = new GameLogic(mode, eventManager, grid, scoreProcessor, levelProcessor, queueProcessor, tickProcessor); // Create gameLogic with dependency injection
            switch(mode) // Apply decorator based on game mode
            {
                case Mode.Classic: case Mode.NES: // No decorator needed in Classic and NES
                    return gameLogic;
                case Mode.FortyLines: // Apply Forty Lines Game Over and Can Hold decorator in Forty Lines gamemode
                    return new FortyLinesGameOverDecorator(new CanHoldTetriminoDecorator(gameLogic));
                case Mode.Blitz: // Apply two minutes Game Over and Can Hold decorator in Blitz gamemode
                    return new TwoMinutesGameOverDecorator(new CanHoldTetriminoDecorator(gameLogic));
                default:
                    throw new Exception($"I don't know what mode is {mode}  to create GameLogic");
            }
        }
    }
}
