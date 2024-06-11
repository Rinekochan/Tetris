using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Model.Logic.LogicProcessor;
using Tetris.Model.Logic.LogicProcessor.RandomStrategies;

namespace Tetris.Model.Factories
{
    public static class QueueProcessorFactory // encapsulates/separates the creation process of QueueProcessor from logic 
    {
        public static QueueProcessor Create(Mode gameMode)
        {
            switch(gameMode)
            {
                case Mode.Classic: case Mode.NES: // If gamemode is Classic or NES, QueueProcessor will use CompleteRandom strategy
                    return new QueueProcessor(new CompleteRandom());
                case Mode.Blitz: case Mode.FortyLines: // If gamemode is Blitz or FortyLines, QueueProcessor will use SevenBagRandom strategy
                    return new QueueProcessor(new SevenBagRandom());
                default:
                    throw new Exception($"I don't know what mode is {gameMode}  to create QueueProcessor");
            }
        }
    }
}
