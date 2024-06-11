using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Controller.Commands;
using Tetris.GameEventManager;
using Tetris.Model.Components.Buttons;

namespace Tetris.Controller
{
    public class GameCommandProcessor // This class handles raw keyboard input and mouse input to execute commands respectively
    {
        private List<GameCommand> _commands;
        public GameCommandProcessor(List<GameCommand> commands)
        {
            _commands = commands;
        }

        public void Execute(EventManager eventManager, string[] messages, List<Button> gameButtons) // Processes event type to distribute it to another methods based on input types
        {
            Enum.TryParse(messages[0], out Event eventType);
            switch (eventType)
            {
                case Event.KeyboardInput:
                    KeyboardHandler(eventManager, messages[1]);
                    break;
                case Event.MouseInput:
                    double.TryParse(messages[1], out double X);
                    double.TryParse(messages[2], out double Y);
                    Point2D mousePosition = new Point2D();
                    mousePosition.X = X;
                    mousePosition.Y = Y;
                    MouseHandler(eventManager, gameButtons, mousePosition);
                    break;
            }
        }
        private void KeyboardHandler(EventManager eventManager, string keyCode) // Handles raw keyboard input
        {
            if (SplashKit.ReadingText()) return; // If the program is listening to the typing text, don't execute commands.
            foreach (GameCommand command in _commands) // Iterate through all available commands keyCode to invoke that command
            {
                if (command.AreYou(keyCode))
                {
                    command.Execute(eventManager);
                }
            }
        }

        private void MouseHandler(EventManager eventManager, List<Button> gameButtons, Point2D mousePosition) // Handles raw mouse input
        {
            foreach(Button gameButton in gameButtons) // Iterate through all GameModel buttons to check if the mouse is in that button
            {
                if (gameButton.IsAt(mousePosition))
                {
                    foreach (GameCommand command in _commands) // Iterate through all available commands to check if that button name is in the list
                    {
                        if (command.AreYou(gameButton.Name))
                        {
                            command.Execute(eventManager);
                        }
                    }
                }
            }
        }
    }
}
