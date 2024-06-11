using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Model.Components.Buttons;

namespace Tetris.Model.Components.ButtonBuilders
{
    // This rectangle builder builds immutable rectangle button class to avoid telescoping constructors
    public class RectangleButtonBuilder : ButtonBuilder<RectangleButton, RectangleButtonBuilder>
    {
        private int _width, _height;
        public RectangleButtonBuilder(string name) : base(name) // Name is required for the button, but other is optional
        {
            _width = _height = 0;
        }

        public RectangleButtonBuilder SetSize(int width, int height) // Set the Size of the rectangle button
        {
            _width = width;
            _height = height;
            return this;
        }

        public override RectangleButton Build() // Build the requested rectangle button
        {
            return new RectangleButton(Name, X, Y, _width, _height, BorderSize, Color, BorderColor);
        }

        public int Width
        {
            get
            {
                return _width;
            }
        }

        public int Height
        {
            get
            {
                return _height;
            }
        }
    }
}
