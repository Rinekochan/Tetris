using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.GameEventManager.GameEvents;

namespace Tetris.GameEventManager
{
    public class EventManager // This class manages the event flow of the game, it notify all its listeners about upcoming events
    {
        private List<IEventListener> _listeners;
        private Queue<IEventListener> _attachQueue; // Attach is queued when the eventmanager is posting/notifying the listeners
        private Queue<IEventListener> _detachQueue; // Detach is queued when the eventmanager is posting/notifying the listeners
        private Queue<GameEvent> _queueEvent; // Event is queued when the eventmanager is posting/notifying the listerners
        private bool _isNotifying;
        public EventManager()
        {
            _listeners = new List<IEventListener>();
            _attachQueue = new Queue<IEventListener>();
            _detachQueue = new Queue<IEventListener>();
            _queueEvent = new Queue<GameEvent>();
            _isNotifying = false;
        }

        public void Attach(IEventListener listener)
        {
            if(!_isNotifying) _listeners.Add(listener);
            else _attachQueue.Enqueue(listener);
        }


        public void Detach(IEventListener listener)
        {
            if(!_isNotifying) _listeners.Remove(listener);
            else _detachQueue.Enqueue(listener);
        }

        private void QueueAttach() // Calls this when the notifying process end to dequeue
        {
            while (_attachQueue.Count > 0)
            {
                _listeners.Add(_attachQueue.Dequeue());
            }
        }

        private void QueueDetach() // Calls this when the notifying process end to dequeue
        {
            while (_detachQueue.Count > 0)
            {
                _listeners.Remove(_detachQueue.Dequeue());
            }
        }

        private void QueueEvent() // Calls this when the notifyhing process end to dequeue
        {
            while (_queueEvent.Count > 0)
            {
                Post(_queueEvent.Dequeue());
            }
        }

        public void Post(GameEvent e) // Notifying all listerners about the event, also queueing Attach, Detach and another event to avoid modifying issue.
        {
            if (_isNotifying)
            {
                _queueEvent.Enqueue(e);
                return;
            }
            _isNotifying = true;

            foreach (IEventListener listener in _listeners)
            {
                listener.Update(e);
            }

            _isNotifying = false;
            QueueAttach();
            QueueDetach();
            QueueEvent();
        }
    }
}
