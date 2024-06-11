using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Model.Logic.LogicProcessor;

namespace Tetris.Model.Factories
{
    public static class TickProcessorFactory // encapsulates/separates the creation process of TickProcessor from logic 
    {
        public static TickProcessor Create()
        {
            return new TickProcessor();
        }
    }
}
