using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.GameEventManager.GameEvents;

namespace Tetris.GameEventManager
{
    // Represents an event listener in the game event management system.
    // This interface defines the Update method, which must be implemented by all concrete event listener classes.
    public interface IEventListener 
    {
        void Update(GameEvent e);
    }
}
