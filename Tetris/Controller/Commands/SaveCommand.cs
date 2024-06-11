using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.GameEventManager;
using Tetris.GameEventManager.GameEvents;

namespace Tetris.Controller.Commands
{
    public class SaveCommand : GameCommand // This command calls the event to save the score and end SplashKit reading text
    {
        public SaveCommand() : base(new string[] { "Save" }) { } // Player clicks on Save Button to use this command

        public override void Execute(EventManager eventManager)
        {
            eventManager.Post(new SaveScoreEvent(SplashKit.TextInput()));
            if (SplashKit.ReadingText()) // Stops reading text if the user didn't enter or escape
            {
                SplashKit.EndReadingText();
            }
        }
    }
}
