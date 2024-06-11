using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Model.Logic.LogicProcessor;

namespace Tetris.Model.Factories
{
    public static class LevelProcessorFactory // encapsulates/separates the creation process of LevelProcessor from logic 
    {
        public static LevelProcessor Create(Mode gameMode)
        {
            switch (gameMode)
            {
                case Mode.Classic: // Level starts at 1 in classic mode
                    return new LevelProcessor(1);
                case Mode.NES: // Level starts at 19 in NES mode
                    return new LevelProcessor(19);
                case Mode.Blitz:
                case Mode.FortyLines: // Level starts at 22 in other modes
                    return new LevelProcessor(22);
                default:
                    throw new Exception($"I don't know what mode is {gameMode}  to create LevelProcessor");
            }
        }
    }
}
