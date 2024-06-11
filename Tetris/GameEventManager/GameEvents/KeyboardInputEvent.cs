using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.GameEventManager.GameEvents
{
    public class KeyboardInputEvent : GameEvent
    {
        private string _keyDown;
        public KeyboardInputEvent(string keyDown) : base(Event.KeyboardInput) // This class represents a raw keyboard input event information
        {
            _keyDown = keyDown;
        }

        public override string[] GetMessage() // Keyboard Input Event also sends the raw keyboard input
        {
            return [Name, _keyDown];
        }

        public string KeyDown
        {
            get
            {
                return _keyDown;
            }
        }
    }
}
