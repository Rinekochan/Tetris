using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Model.Components.ButtonBuilders;

namespace Tetris.Model.Components.Buttons
{
    public class CircleButton : Button // This class represents a circle button
    {
        private int _radius;

        public CircleButton(string name, int x, int y, int radius, int borderSize, Color color, Color borderColor) : base(name, x, y, borderSize, color, borderColor)
        {
            _radius = radius;
        }

        public override void Draw()
        {
            base.Draw();
            SplashKit.FillCircle(Color, X, Y, _radius);
        }

        protected override void DrawBorder() // Draw border of the circle button
        {
            SplashKit.FillCircle(BorderColor, X, Y, _radius + BorderSize);
        }

        public override bool IsAt(Point2D pt) // This method check if the mouse position is in the circle button
        {
            return SplashKit.PointInCircle(pt, SplashKit.CircleAt(X, Y, _radius));
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
