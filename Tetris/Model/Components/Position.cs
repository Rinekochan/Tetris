using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Model.Components
{
    public class Position // This class represents a position information of a cell / tetrimino
    {
        private int _row, _column;
        public Position(int row, int column)
        {
            _column = column;
            _row = row;
        }

        public void Modify(int rows, int cols) // Modify the current position by rows and cols
        {
            _row += rows;
            _column += cols;
        }

        public void Modify(Position p) // Modify the current position by position
        {
            _row += p.Row;
            _column += p.Column;
        }

        public int Row
        {
            get
            {
                return _row;
            }
        }

        public int Column
        {
            get
            {
                return _column;
            }
        }
    }
}
