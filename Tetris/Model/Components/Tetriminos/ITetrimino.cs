using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace Tetris.Model.Components.Tetriminos
{
    public class ITetrimino : Tetrimino // This class represents I-shaped Tetrimino
    {
        public ITetrimino() : base
            (
                "I",
                [
                    [new Cell(Color.Cyan, new Position(1, 0), true), new Cell(Color.Cyan, new Position(1, 1), true), new Cell(Color.Cyan, new Position(1, 2), true), new Cell(Color.Cyan, new Position(1, 3), true)],
                    [new Cell(Color.Cyan, new Position(0, 2), true), new Cell(Color.Cyan, new Position(1, 2), true), new Cell(Color.Cyan, new Position(2, 2), true), new Cell(Color.Cyan, new Position(3, 2), true)],
                    [new Cell(Color.Cyan, new Position(2, 0), true), new Cell(Color.Cyan, new Position(2, 1), true), new Cell(Color.Cyan, new Position(2, 2), true), new Cell(Color.Cyan, new Position(2, 3), true)],
                    [new Cell(Color.Cyan, new Position(0, 1), true), new Cell(Color.Cyan, new Position(1, 1), true), new Cell(Color.Cyan, new Position(2, 1), true), new Cell(Color.Cyan, new Position(3, 1), true)]
                ],
                new Position(0, 3)
            )
        {

        }
    }
}
