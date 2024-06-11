using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;
using Tetris.Model.Components.ButtonBuilders;

namespace Tetris.Model.Components.Buttons
{
    // Represents an abstract base class for buttons in the game.
    // This class defines the basic properties and methods that all buttons must implement.
    public abstract class Button
    {
        private int _x, _y, _borderSize;
        private Color _color, _borderColor;
        private string _name;

        public Button(string name, int x, int y, int borderSize, Color color, Color borderColor)
        {
            _name = name;
            _x = x;
            _y = y;
            _borderSize = borderSize;
            _color = color;
            _borderColor = borderColor;
        }

        // Draws the button.
        // This method can be overridden by derived classes to provide specific drawing logic.
        public virtual void Draw()
        {
            DrawBorder();
        }

        // Draws the border of the button.
        // This method must be implemented by derived classes to define specific border drawing logic.
        protected abstract void DrawBorder();

        // Determines whether the specified point is within the button's bounds.
        public abstract bool IsAt(Point2D pt);

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public int X
        {
            get
            {
                return _x;
            }
        }

        public int Y
        {
            get
            {
                return _y;
            }
        }

        public Color Color
        {
            get
            {
                return _color;
            }
        }

        public int BorderSize
        {
            get
            {
                return _borderSize;
            }
        }

        public Color BorderColor
        {
            get
            {
                return _borderColor;
            }
        }
    }
}
