using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Model.Components.Buttons;

namespace Tetris.Model.Components.ButtonBuilders
{
    // This builder builds immutable circle button class to avoid telescoping constructors
    public class CircleButtonBuilder : ButtonBuilder<CircleButton, CircleButtonBuilder>
    {
        private int _radius;
        public CircleButtonBuilder(string name) : base(name) // Name is required for the button, but other is optional
        {
            _radius = 0;
        }

        public CircleButtonBuilder SetRadius(int radius) // Set Radius of the circle button
        {
            _radius = radius;
            return this;
        }

        public override CircleButton Build() // Build the requested circle button
        {
            return new CircleButton(Name, X, Y, _radius, BorderSize, Color, BorderColor);
        }

        public int Radius
        {
            get
            {
                return _radius;
            }
        }
    }
}
