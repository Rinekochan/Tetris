using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Tetris.Model.Components;

namespace Tetris.Model.Factories
{
    public static class GridFactory // encapsulates/separates the creation process of Grid from logic 
    {
        public static Grid Create(Mode gameMode) 
        {
            switch(gameMode)
            {
                default: // This is our current set up, but it's allow for extension in future
                    return new Grid(22, 10);
            }
        }
    }
}
