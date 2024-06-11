using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Tetris.Model.States;
using Tetris.View.Drawers.IngameDrawStrategies.ExtraIngameDrawStrategies;

namespace Tetris.View.StaticFactories
{
    public static class ExtraIngameDrawFactory
    {
        public static IExtraIngameDrawStrategy Create(Mode mode) // separates/encapsulates the creation process of ExtraIngameDrawStrategy from logic
        {
            switch (mode)
            {
                case Mode.Classic: case Mode.NES: // If gamemode is Classic or NES, IngameDrawer will use ClassicNESExtraDraw strategy
                    return new ClassicNESExtraDrawStrategy();
                case Mode.Blitz: // If gamemode is Blitz, IngameDrawer will use BlitzExtraIngameDraw strategy
                    return new BlitzExtraIngameDrawStrategy();
                case Mode.FortyLines: // If gamemode is FortyLines, IngameDrawer will use FortyLinesExtraIngameDraw strategy
                    return new FortyLinesExtraIngameDrawStrategy();
                default:
                    throw new Exception($"I don't know what mode is {mode}  to create ExtraIngameDrawStrategy");
            }
        }
    }
}
