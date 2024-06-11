using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Model.Logic.LogicProcessor;

namespace Tetris.Model.Factories
{
    public static class ScoreProcessorFactory // encapsulates/separates the creation process of ScoreProcessor from logic 
    {
        public static ScoreProcessor Create()
        {
            return new ScoreProcessor();
        }
    }
}
