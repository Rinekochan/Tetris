using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace Tetris.Model.Components.Tetriminos
{
    public class ZTetrimino : Tetrimino // This class represents Z-shaped Tetrimino
    {
        public ZTetrimino() : base
            (
                "Z",
                [
                    [new Cell(Color.SwinburneRed, new Position(0, 0), true), new Cell(Color.SwinburneRed, new Position(0, 1), true), new Cell(Color.SwinburneRed, new Position(1, 1), true), new Cell(Color.SwinburneRed, new Position(1, 2), true)],
                    [new Cell(Color.SwinburneRed, new Position(0, 2), true), new Cell(Color.SwinburneRed, new Position(1, 1), true), new Cell(Color.SwinburneRed, new Position(1, 2), true), new Cell(Color.SwinburneRed, new Position(2, 1), true)],
                    [new Cell(Color.SwinburneRed, new Position(1, 0), true), new Cell(Color.SwinburneRed, new Position(1, 1), true), new Cell(Color.SwinburneRed, new Position(2, 1), true), new Cell(Color.SwinburneRed, new Position(2, 2), true)],
                    [new Cell(Color.SwinburneRed, new Position(0, 1), true), new Cell(Color.SwinburneRed, new Position(1, 0), true), new Cell(Color.SwinburneRed, new Position(1, 1), true), new Cell(Color.SwinburneRed, new Position(2, 0), true)]
                ],
                new Position(0, 3)
            )
        {

        }
    }
}
