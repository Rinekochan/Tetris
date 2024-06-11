using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Model.Components.Buttons;

namespace Tetris.Model.Components.ButtonBuilders
{
    // This builder builds immutable button class to avoid telescoping constructors
    public abstract class ButtonBuilder<TButton, TButtonBuilder> // Use generic builder to be able to inherit this base class properly
        where TButton : Button
        where TButtonBuilder : ButtonBuilder<TButton, TButtonBuilder>
    {
        private readonly TButtonBuilder _builderInstance;
        private int _x, _y, _borderSize;
        private Color _color, _borderColor;
        private string _name;

        public ButtonBuilder(string name) // Name is required for the button, but other is optional
        {
            _builderInstance = (TButtonBuilder)this; // Cast it with generic ButtonBuilder type
            _name = name;
            _x = _y = _borderSize = 0;
            _color = Color.Black;
            _borderColor = Color.White;
        }

        public TButtonBuilder SetPosition(int x, int y) // Set Position of the requested buttion
        {
            _x = x;
            _y = y;
            return _builderInstance;
        }

        public TButtonBuilder SetColor(Color color) // Set Color of the requested buttion
        {
            _color = color;
            return _builderInstance;
        }

        public TButtonBuilder SetBorderSize(int borderSize) // Set Border Size of the requested button
        {
            _borderSize = borderSize;
            return _builderInstance;
        }

        public TButtonBuilder SetBorderColor(Color borderColor) // Set Border Color of the requested button
        {
            _borderColor = borderColor;
            return _builderInstance;
        }

        public abstract TButton Build(); // Build the requested button, derived classes must implements and specifies this method

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
