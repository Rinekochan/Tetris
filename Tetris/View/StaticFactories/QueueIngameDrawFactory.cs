using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.View.Drawers.IngameDrawStrategies.QueueIngameDrawStrategies;
using Tetris.View.Drawers.IngameDrawStrategies.RecordIngameDrawStrategies;

namespace Tetris.View.StaticFactories
{
    public static class QueueIngameDrawFactory
    {
        public static IQueueIngameDrawStrategy Create(Mode mode) // separates/encapsulates the creation process of IQueueIngameDrawStrategy from logic
        {
            switch (mode)
            {
                case Mode.Classic: case Mode.NES: // If gamemode is Classic and NES, IngameDrawer will use OneQueueIngameDraw strategy
                    return new OneQueueIngameDrawStrategy();
                case Mode.Blitz: case Mode.FortyLines:// If gamemode is Blitz and FortyLines, IngameDrawer will use FiveQueueIngameDraw strategy
                    return new FiveQueueIngameDrawStrategy();
                default:
                    throw new Exception($"I don't know what mode is {mode}  to create IQueueIngameDrawStrategy");
            }
        }
    }
}
