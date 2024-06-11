using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Model.Components.ButtonBuilders;

namespace Tetris.Model.Components.Buttons
{
    public class RectangleButton : Button // This class represents a rectangle button
    {
        private int _width, _height;

        public RectangleButton(string name, int x, int y, int width, int height, int borderSize, Color color, Color borderColor) : base(name, x, y, borderSize, color, borderColor)
        {
            _width = width;
            _height = height;
        }

        public override void Draw() 
        {
            base.Draw();
            SplashKit.FillRectangle(Color, X, Y, _width, _height);
        }

        protected override void DrawBorder() // Draw border of the rectangle button
        {
            SplashKit.FillRectangle(BorderColor, X - BorderSize, Y - BorderSize, _width + BorderSize * 2, _height + BorderSize * 2);
        }

        public override bool IsAt(Point2D pt) // This method check if the mouse position is in the rectangle button
        {
            return SplashKit.PointInRectangle(pt, SplashKit.RectangleFrom(X, Y, _width, _height));
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
