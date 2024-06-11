using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Model.Components.Tetriminos;

namespace Tetris.Model.Factories
{
    public static class TetriminoFactory // encapsulates/separates the creation process of Tetriminos from logic 
    {
        public static Tetrimino Create(string id)
        {
            switch (id)
            {
                case "I":
                    return new ITetrimino();
                case "J":
                    return new JTetrimino();
                case "L":
                    return new LTetrimino();
                case "O":
                    return new OTetrimino();
                case "S":
                    return new STetrimino();
                case "T":
                    return new TTetrimino();
                case "Z":
                    return new ZTetrimino();
                default:
                    throw new Exception("Unknown Tetrimino Id");
            }

        }
    }
}
