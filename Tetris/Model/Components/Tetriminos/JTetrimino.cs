using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace Tetris.Model.Components.Tetriminos
{
    public class JTetrimino : Tetrimino // This class represents J-shaped Tetrimino
    {
        public JTetrimino() : base
            (
                "J",
                [
                    [new Cell(Color.RoyalBlue, new Position(0, 0), true), new Cell(Color.RoyalBlue, new Position(1, 0), true), new Cell(Color.RoyalBlue, new Position(1, 1), true), new Cell(Color.RoyalBlue, new Position(1, 2), true)],
                    [new Cell(Color.RoyalBlue, new Position(0, 1), true), new Cell(Color.RoyalBlue, new Position(0, 2), true), new Cell(Color.RoyalBlue, new Position(1, 1), true), new Cell(Color.RoyalBlue, new Position(2, 1), true)],
                    [new Cell(Color.RoyalBlue, new Position(1, 0), true), new Cell(Color.RoyalBlue, new Position(1, 1), true), new Cell(Color.RoyalBlue, new Position(1, 2), true), new Cell(Color.RoyalBlue, new Position(2, 2), true)],
                    [new Cell(Color.RoyalBlue, new Position(0, 1), true), new Cell(Color.RoyalBlue, new Position(1, 1), true), new Cell(Color.RoyalBlue, new Position(2, 0), true), new Cell(Color.RoyalBlue, new Position(2, 1), true)]
                ],
                new Position(0, 3)
            )
        {

        }
    }
}
