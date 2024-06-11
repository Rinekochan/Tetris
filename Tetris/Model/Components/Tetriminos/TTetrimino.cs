using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace Tetris.Model.Components.Tetriminos
{
    public class TTetrimino : Tetrimino // This class represents T-shaped Tetrimino
    {
        public TTetrimino() : base
            (
                "T",
                [
                    [new Cell(Color.DarkViolet, new Position(0, 1), true), new Cell(Color.DarkViolet, new Position(1, 0), true), new Cell(Color.DarkViolet, new Position(1, 1), true), new Cell(Color.DarkViolet, new Position(1, 2), true)],
                    [new Cell(Color.DarkViolet, new Position(0, 1), true), new Cell(Color.DarkViolet, new Position(1, 1), true), new Cell(Color.DarkViolet, new Position(1, 2), true), new Cell(Color.DarkViolet, new Position(2, 1), true)],
                    [new Cell(Color.DarkViolet, new Position(1, 0), true), new Cell(Color.DarkViolet, new Position(1, 1), true), new Cell(Color.DarkViolet, new Position(1, 2), true), new Cell(Color.DarkViolet, new Position(2, 1), true)],
                    [new Cell(Color.DarkViolet, new Position(0, 1), true), new Cell(Color.DarkViolet, new Position(1, 0), true), new Cell(Color.DarkViolet, new Position(1, 1), true), new Cell(Color.DarkViolet, new Position(2, 1), true)]
                ],
                new Position(0, 3)
            )
        {

        }
    }
}
