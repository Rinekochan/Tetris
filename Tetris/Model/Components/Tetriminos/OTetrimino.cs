using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace Tetris.Model.Components.Tetriminos
{
    public class OTetrimino : Tetrimino // This class represents O-shaped Tetrimino
    {
        public OTetrimino() : base
            (
                "O",
                [
                    [new Cell(Color.Yellow, new Position(0, 0), true), new Cell(Color.Yellow, new Position(0, 1), true), new Cell(Color.Yellow, new Position(1, 0), true), new Cell(Color.Yellow, new Position(1, 1), true)]
                ],
                new Position(0, 4)
            )
        {

        }
    }
}
