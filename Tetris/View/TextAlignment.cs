using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.View
{
    public static class TextAlignment // This static class helps text alignment
    {
        public static int HorizontalCenter(string text, string font,  int fontSize) // Aligns center the text horizontally in the window
        {
            int textWidth = SplashKit.TextWidth(text, font, fontSize);
            return SplashKit.WindowWidth("Tetris") / 2 - textWidth / 2;
        }

        public static int HorizontalCenter(string text, string font, int fontSize, int boxX, int boxSize) // Aligns center the text horizontally in the box
        {
            int textWidth = SplashKit.TextWidth(text, font, fontSize);
            return boxX + boxSize / 2 - textWidth / 2;
        }

        public static int VerticalCenter(string text, string font, int fontSize) // Aligns center the text vertically in the window
        {
            int textHeight = SplashKit.TextHeight(text, font, fontSize);
            return SplashKit.WindowHeight("Tetris") / 2 - textHeight / 2;
        }

        public static int VerticalCenter(string text, string font, int fontSize, int boxY, int boxSize) // Aligns center the text vertically in the box
        {
            int textHeight = SplashKit.TextHeight(text, font, fontSize);
            return boxY + boxSize / 2 - textHeight / 2;
        }
    }
}
