using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Model;

namespace Tetris.View.Drawers
{
    public class HelpDrawer : Drawer // This drawer draws Help state
    {
        public HelpDrawer() : base(Color.Black)
        {

        }

        public override void Draw(GameModel gameModel)
        {
            base.Draw(gameModel);
            // Draw Return text on return button
            SplashKit.DrawText("RETURN", Color.White, "ModernBold", 24, 30, 20);
            // Draw available controls in the game
            SplashKit.DrawText("CONTROLS", Color.White, "ModernBold", 40, TextAlignment.HorizontalCenter("CONTROLS", "ModernBold", 40), 20);
            SplashKit.DrawText("Move Left: Left Arrow", Color.White, "Modern", 24, 30, 60);     
            SplashKit.DrawText("Move Right: Right Arrow", Color.White, "Modern", 24, 30, 80);     
            SplashKit.DrawText("Move Down (Soft Drop): Down Arrow", Color.White, "Modern", 24, 30, 100);     
            SplashKit.DrawText("Hard Drop: Space Bar", Color.White, "Modern", 24, 30, 120);     
            SplashKit.DrawText("Rotate Clockwise: Up Arrow, Key X", Color.White, "Modern", 24, 30, 140);     
            SplashKit.DrawText("Rotate Counter-Clockwise: Key Z", Color.White, "Modern", 24, 30, 160);     
            SplashKit.DrawText("Hold Tetrimino (Only available in Blitz and 40 Lines): Left Shift, Key C", Color.White, "Modern", 24, 30, 180);  
            // Draw available shortcuts in the game
            SplashKit.DrawText("SHORTCUTS", Color.White, "ModernBold", 40, TextAlignment.HorizontalCenter("SHORTCUTS", "ModernBold", 40), 210);
            SplashKit.DrawText("New Classic Game: Key 1", Color.White, "Modern", 24, 30, 250);
            SplashKit.DrawText("New NES Game: Key 2", Color.White, "Modern", 24, 30, 270);
            SplashKit.DrawText("New 40 Lines Game: Key 3", Color.White, "Modern", 24, 30, 290);
            SplashKit.DrawText("New Blitz Game: Key 4", Color.White, "Modern", 24, 30, 310);
            SplashKit.DrawText("Help: Key H", Color.White, "Modern", 24, 30, 330);
            SplashKit.DrawText("Quit: Key Q", Color.White, "Modern", 24, 30, 350);
            SplashKit.DrawText("Pause Game: Key ESCAPE", Color.White, "Modern", 24, 30, 370);
            SplashKit.DrawText("Continue/Resume Game: Key ENTER", Color.White, "Modern", 24, 30, 390);
            SplashKit.DrawText("Restart Game: Key S", Color.White, "Modern", 24, 30, 410);
            SplashKit.DrawText("Return To Menu (In Help, Pause Menu, Game Over): Key M", Color.White, "Modern", 24, 30, 430);
            SplashKit.DrawText("GAME MODES", Color.White, "ModernBold", 40, TextAlignment.HorizontalCenter("GAME MODES", "ModernBold", 40), 460);
            // Draw gamemodes details and rules in the game
            SplashKit.DrawText("Classic: Get the highest score until you lose! (recommended for beginner)", Color.White, "Modern", 24, 30, 500);
            SplashKit.DrawText("Rule: Start from Level 1, 1 queue display, completely random queue, hold disable.", Color.White, "Modern", 24, 30, 520);
            SplashKit.DrawText("NES: Get the highest score until you lose!", Color.White, "Modern", 24, 30, 550);
            SplashKit.DrawText("Rule: Start from Level 19, 1 queue display, completely random queue, hold disable.", Color.White, "Modern", 24, 30, 570);
            SplashKit.DrawText("40 Lines: How fast can you clear 40 lines?", Color.White, "Modern", 24, 30, 600);
            SplashKit.DrawText("Rule: Start from Level 22, 5 queue display, 7-bag random queue, hold enable.", Color.White, "Modern", 24, 30, 620);
            SplashKit.DrawText("Blitz: Get the highest score in 2 minutes!", Color.White, "Modern", 24, 30, 650);
            SplashKit.DrawText("Rule: Start from Level 22, 5 queue display, 7-bag random queue, hold enable.", Color.White, "Modern", 24, 30, 670);
        }
    }
}
