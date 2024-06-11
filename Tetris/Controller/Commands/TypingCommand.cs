using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.GameEventManager.GameEvents;
using Tetris.GameEventManager;
using SplashKitSDK;

namespace Tetris.Controller.Commands
{
    public class TypingCommand : GameCommand // This command calls the SplashKit to start reading the text from player (To write player name to save score)
    {
        public TypingCommand() : base(new string[] { "Typing" }) { } // Player clicks on Typing Text Box to use this command

        public override void Execute(EventManager eventManager)
        {
            SplashKit.StartReadingText(SplashKit.RectangleFrom(500, 480, 300, 60)); // SplashKit starts collecting inputs from player
        }
    }
}
