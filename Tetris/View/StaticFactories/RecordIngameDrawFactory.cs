using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.View.Drawers.IngameDrawStrategies.ExtraIngameDrawStrategies;
using Tetris.View.Drawers.IngameDrawStrategies.RecordIngameDrawStrategies;

namespace Tetris.View.StaticFactories
{
    public static class RecordIngameDrawFactory
    {
        public static RecordIngameDrawStrategy Create(Mode mode) // separates/encapsulates the creation process of RecordIngameDrawStrategy from logic
        {
            switch (mode)
            {
                case Mode.Classic: // If gamemode is Classic, IngameDrawer will use ClassicNESExtraDraw strategy
                    return new ClassicScoreIngameDrawStrategy();
                case Mode.NES: // If gamemode is NES, IngameDrawer will use NESScoreIngameDraw strategy
                    return new NESScoreIngameDrawStrategy();
                case Mode.Blitz: // If gamemode is Blitz, IngameDrawer will use BlitzScoreIngameDraw strategy
                    return new BlitzScoreIngameDrawStrategy();
                case Mode.FortyLines: // If gamemode is FortyLines, IngameDrawer will use TimeIngameDraw strategy
                    return new TimeIngameDrawStrategy();
                default:
                    throw new Exception($"I don't know what mode is {mode}  to create RecordIngameDrawStrategy");
            }
        }
    }
}
