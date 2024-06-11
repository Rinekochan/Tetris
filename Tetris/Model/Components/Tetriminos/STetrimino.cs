using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace Tetris.Model.Components.Tetriminos
{
    public class STetrimino : Tetrimino // This class represents S-shaped Tetrimino
    {
        public STetrimino() : base
            (
                "S",
                [
                    [new Cell(Color.LawnGreen, new Position(0, 1), true), new Cell(Color.LawnGreen, new Position(0, 2), true), new Cell(Color.LawnGreen, new Position(1, 0), true), new Cell(Color.LawnGreen, new Position(1, 1), true)],
                    [new Cell(Color.LawnGreen, new Position(0, 1), true), new Cell(Color.LawnGreen, new Position(1, 1), true), new Cell(Color.LawnGreen, new Position(1, 2), true), new Cell(Color.LawnGreen, new Position(2, 2), true)],
                    [new Cell(Color.LawnGreen, new Position(1, 1), true), new Cell(Color.LawnGreen, new Position(1, 2), true), new Cell(Color.LawnGreen, new Position(2, 0), true), new Cell(Color.LawnGreen, new Position(2, 1), true)],
                    [new Cell(Color.LawnGreen, new Position(0, 0), true), new Cell(Color.LawnGreen, new Position(1, 0), true), new Cell(Color.LawnGreen, new Position(1, 1), true), new Cell(Color.LawnGreen, new Position(2, 1), true)]
                ],
                new Position(0, 3)
            )
        {

        }
    }
}
