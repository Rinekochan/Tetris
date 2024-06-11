using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;
using Tetris.Model.Components;

namespace Tetris.Model.Components.Tetriminos
{
    // Represents a Tetrimino
    // This class encapsulates the methods and attributes necessary for a Tetrimino's behavior and state.
    public abstract class Tetrimino
    {
        private string _id;
        private Cell[][] _shape;
        private int _rotationState;
        private Position _position;

        public Tetrimino(string id, Cell[][] shape, Position position)
        {
            _id = id;
            _shape = shape;
            _rotationState = 0;
            _position = position;
        }

        public void Move(int rows, int cols) // Move the Tetrimino by rows and cols
        {
            _position.Modify(rows, cols);
        }

        // Current Cell Postion = Current Tetrimino Positon + Cell Position in _shape
        public Cell[] GetCellPosition()
        {
            List<Cell> currentCellPosition = new List<Cell>();

            foreach (Cell currentCell in _shape[_rotationState])
            {
                Position currentPosition = new Position(currentCell.Position.Row, currentCell.Position.Column);
                currentPosition.Modify(_position);
                currentCellPosition.Add(new Cell(currentCell.Color, currentPosition, true));
            }
            return currentCellPosition.ToArray();
        }

        public void Rotate(bool clockwise) // Rotate the tetrimino to change the _shape array
        {
            if (clockwise)
            {
                _rotationState = (_rotationState + 1) % _shape.Length;
            }
            else
            {
                _rotationState -= 1;
                if (_rotationState < 0) _rotationState = _shape.Length - 1;
            }
        }

        public void Draw(int x, int y) // Tell the Cell in _shape to draw itself based on current position
        {
            Cell[] currentShape = GetCellPosition();

            foreach (Cell cell in currentShape)
            {
                cell.Draw(x, y, 1, Color.RGBColor(21, 21, 21));
            }
        }

        public string ID
        {
            get
            {
                return _id;
            }
        }

        public int RotationState
        {
            get
            {
                return _rotationState;
            }
        }

        public Position Position
        {
            get
            {
                return _position;
            }
        }
    }
}
