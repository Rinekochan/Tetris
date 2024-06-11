using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;
using Tetris.Model;
using Tetris.Model.Components.Buttons;

namespace Tetris.View.Drawers
{
    public abstract class Drawer // This drawer abstracts the graphic draw of each state
    {
        private Color _background;
        private string? _bitmap;
        public Drawer(Color Background)
        {
            _background = Background;
            _bitmap = null;
        }

        public Drawer(Color background, string bitmap) : this(background) // It can either use normal background color, or use an image.
        {
            _bitmap = bitmap;
        }

        public virtual void Draw(GameModel gameModel)
        {
            SplashKit.ClearScreen(_background);
            if (_bitmap != null) SplashKit.DrawBitmap(_bitmap, 0, 0);
            foreach (Button button in gameModel.GameButtons) // Draw all buttons in current Game State in Game Model
            {
                button.Draw();
            }
        }

        public Color Background
        {
            get
            {
                return _background;
            }
        }
    }
}
