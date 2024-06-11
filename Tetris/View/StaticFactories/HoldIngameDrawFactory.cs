using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Tetris.View.Drawers.IngameDrawStrategies.HoldIngameDrawStrategies;

namespace Tetris.View.StaticFactories
{
    public static class HoldIngameDrawFactory
    {
        public static IHoldIngameDrawStrategy Create(Mode mode) // separates/encapsulates the creation process of IHoldIngameDrawStrategy from logic
        {
            switch (mode)
            {
                case Mode.Classic: case Mode.NES: // If gamemode is Classic and NES, IngameDrawer will use NoHoldIngameDraw strategy
                    return new NoHoldIngameDrawStrategy();
                case Mode.Blitz: case Mode.FortyLines:// If gamemode is Blitz and FortyLines, IngameDrawer will use HasHoldIngameDraw strategy
                    return new HasHoldIngameDrawStrategy();
                default:
                    throw new Exception($"I don't know what mode is {mode}  to create IHoldIngameDrawStrategy");
            }
        }
    }
}
