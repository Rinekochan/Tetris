using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.GameEventManager.GameEvents
{
    public class SaveScoreEvent : GameEvent
    {
        private string _playerName;
        public SaveScoreEvent(string playerName) : base(Event.SaveScore) // This class represents a save score event
        {
            _playerName = playerName;
        }

        public override string[] GetMessage() // Save Score Event also sends the player name to save score
        {
            return [Name, _playerName];
        }

        public string PlayerName
        {
            get
            {
                return _playerName;
            }
        }
    }
}
