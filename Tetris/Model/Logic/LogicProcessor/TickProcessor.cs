using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Model.Logic.LogicProcessor
{
    public class TickProcessor // This class processes current ticks of the game logic
    {
        private SplashKitSDK.Timer _timer, _lastDropTimer;
        public TickProcessor()
        {
            _timer = new SplashKitSDK.Timer("Ingame Timer"); // This timer is used to check In-game ticks.
            _lastDropTimer = new SplashKitSDK.Timer("Last Drop Timer"); // This timer is used to automatically drop a tetrimino down.
        }

        public void Start() // This will start the timer (when the player is at the start of a Ingame state)
        {
            _timer.Start();
            _lastDropTimer.Start();
        }

        public void Pause() // This will pause the timer (when the player is in PauseMenu state)
        {
            _timer.Pause();
            _lastDropTimer.Pause();
        }

        public void Resume() // This will resume the timer (when the player continue the game from PauseMenu state)
        {
            _timer.Resume();
            _lastDropTimer.Resume();
        }

        public void Stop() // This will stop the timer (when the game is over)
        {
            _timer.Stop();
            _lastDropTimer.Stop();
        }

        public SplashKitSDK.Timer IngameTimer
        {
            get
            {
                return _timer;
            }
            set
            {
                _timer = value;
            }
        }

        public SplashKitSDK.Timer LastDropTimer
        {
            get
            {
                return _lastDropTimer;
            }
            set
            {
                _lastDropTimer = value;
            }
        }
    }
}
