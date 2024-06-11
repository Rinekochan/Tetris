using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;
namespace Tetris.GameEventManager.GameEvents
{
    public class MouseInputEvent : GameEvent
    {
        private Point2D _mousePosition;
        public MouseInputEvent(Point2D mousePosition) : base(Event.MouseInput) // This class represents a raw mouse input event information
        {
            _mousePosition = mousePosition;
        }

        public override string[] GetMessage() // Mouse Input Event also sends the raw mouse position input
        {
            return [Name, _mousePosition.X.ToString(), _mousePosition.Y.ToString()];
        }

        public Point2D MousePosition
        {
            get
            {
                return _mousePosition;
            }
        }
    }
}
