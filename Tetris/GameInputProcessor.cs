using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;
using Tetris.GameEventManager;
using Tetris.GameEventManager.GameEvents;

namespace Tetris
{
    public class GameInputProcessor : IEventListener // This class listens to the raw input (keyboard, mouse) and send the events accordingly
    {
        private EventManager _eventManager;

        public GameInputProcessor(EventManager eventManger)
        {
            _eventManager = eventManger;
            _eventManager.Attach(this);
        }

        public void Update(GameEvent e)
        {
            Enum.TryParse(e.GetMessage()[0], out Event eventType);
            switch (eventType)
            {
                case Event.Tick:
                    Listening(0); // This is for mouse input listener
                    break;
            }
        }

        public void Listening(int code) // Listening to raw mouse and keyboard input and Post game event about it.
        {
            
            if (SplashKit.MouseClicked(MouseButton.LeftButton))
            {
                _eventManager.Post(new MouseInputEvent(SplashKit.MousePosition()));
            }
            else if(code > 0)
            {
                _eventManager.Post(new KeyboardInputEvent(Enum.GetName(typeof(KeyCode), code)));
            }
        }
    }
}
