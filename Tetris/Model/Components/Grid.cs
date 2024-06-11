using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace Tetris.Model.Components
{
    public class Grid // This class represents a grid information
    {
        private int _numRows, _numCols;
        private Cell[,] _matrix;

        public Grid(int numRows, int numCols)
        {
            _numRows = numRows;
            _numCols = numCols;
            _matrix = new Cell[_numRows, _numCols];

            for (int col = 0; col < _numCols; col++)
            {
                for (int row = 0; row < _numRows; row++)
                {
                    _matrix[row, col] = new Cell(Color.Black, new Position(row, col), false);
                }
            }
        }

        public void Draw(int x, int y) // Draw the grid
        {
            foreach (Cell cell in _matrix)
            {
                cell.Draw(x, y, 1, Color.RGBColor(21, 21, 21));

                if (cell.Position.Column == 0) cell.DrawBorderLeft(x, y, Color.White);
                if (cell.Position.Column == _numCols - 1) cell.DrawBorderRight(x, y, Color.White);
                if (cell.Position.Row == _numRows - 1) cell.DrawBorderBottom(x, y, Color.White);
            }
        }

        public bool IsValid(int row, int col) // Check if the row and cow provided is valid
        {
            return IsInside(row, col) && _matrix[row, col].Occupied == false;
        }

        public bool IsValid(Position p) // Check if the row and cow provided is valid
        {
            return IsInside(p.Row, p.Column) && _matrix[p.Row, p.Column].Occupied == false;
        }

        public int ClearFullRows() // This method clears all fulled rows
        {
            int clearedRows = 0;
            for (int row = _numRows - 1; row >= 0; row--)
            {
                if (IsRowFull(row)) clearedRows++;
                else if (clearedRows > 0)
                {
                    MoveRowsDown(row, clearedRows);
                }
            }
            return clearedRows;
        }

        public void Reset() // Reset the grid
        {
            for (int row = 0; row < _numRows; row++)
            {
                for (int col = 0; col < _numCols; col++)
                {
                    _matrix[row, col] = new Cell(Color.Black, new Position(row, col), false);
                }
            }
        }

        private bool IsInside(int row, int col) // Check if the row and cow provided is inside the grid
        {
            return row >= 0 && col >= 0 && row < _numRows && col < _numCols;
        }

        private bool IsRowFull(int row) // Check if the row is full of occupied cell
        {
            for (int col = 0; col < _numCols; col++)
            {

                if (!_matrix[row, col].Occupied) return false;
            }
            return true;
        }

        private void MoveRowsDown(int row, int rowsDown) // Move the row down for rowsDown times
        {
            for (int col = 0; col < _numCols; col++)
            {
                _matrix[row + rowsDown, col] = new Cell(_matrix[row, col].Color, new Position(row + rowsDown, col), _matrix[row, col].Occupied);
                _matrix[row, col] = new Cell(Color.Black, new Position(row, col), false);
            }
        }

        public Cell[,] Matrix
        {
            get
            {
                return _matrix;
            }
        }
    }
}
