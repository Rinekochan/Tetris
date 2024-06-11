using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace Tetris.Model.Components
{
    public class Cell // This class represents a cell information of a grid/tetrimino
    {
        private int _size;
        private Color _color;
        private bool _occupied;
        private Position _position;

        public Cell(Color color, Position position, bool occupied)
        {
            _size = 30;
            _color = color;
            _position = position;
            _occupied = occupied;
        }

        public Position CurrentPosition(int x, int y) // x, y is the start position, so we have to calculate current position.
        {
            int _currentX = x + _size * _position.Column;
            int _currentY = y + _size * _position.Row;
            return new Position(_currentY, _currentX);
        }

        public void Draw(int x, int y, int borderSize, Color borderColor) // Draw full cell with borders
        {
            Position currentPosition = CurrentPosition(x, y);
            SplashKit.FillRectangle(_color, currentPosition.Column, currentPosition.Row, _size, _size);
            DrawBorder(currentPosition.Column, currentPosition.Row, borderColor);
        }

        public void DrawBorderLeft(int x, int y, Color borderLeft) // Change border left color
        {
            Position currentPosition = CurrentPosition(x, y);
            SplashKit.FillRectangle(borderLeft, currentPosition.Column, currentPosition.Row, 2, _size);
        }

        public void DrawBorderRight(int x, int y, Color borderRight) // Change border right color
        {
            Position currentPosition = CurrentPosition(x, y);
            SplashKit.FillRectangle(borderRight, currentPosition.Column + _size, currentPosition.Row, 2, _size);
        }

        public void DrawBorderBottom(int x, int y, Color borderBottom) // Change border bottom color
        {
            Position currentPosition = CurrentPosition(x, y);
            SplashKit.FillRectangle(borderBottom, currentPosition.Column, currentPosition.Row + _size, _size + 2, 2);
        }

        public void DrawBorder(int x, int y, Color borderColor) // Change all borders color
        {
            SplashKit.DrawRectangle(borderColor, x, y, _size, _size);
        }
        public bool Occupied
        {
            set
            {
                _occupied = value;
            }
            get
            {
                return _occupied;
            }
        }

        public Color Color
        {
            get
            {
                return _color;
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
