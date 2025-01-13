using System;
using System.Collections.Generic;

namespace GameScript.Runtime.Framework
{
    public class EventManager : Singleton<EventManager>
    {
        public delegate void EventHandler(int eventType, object param);

        private readonly Dictionary<int, List<EventHandler>> _handlers = new();

        public void Clear()
        {
            foreach (var list in _handlers.Values)
            {
                list.Clear();
            }
        }
        
        public void Listen(int eventType, EventHandler handler)
        {
            if (!_handlers.TryGetValue(eventType, out var list))
            {
                list = new();
                _handlers.Add(eventType, list);
            }
            list.Add(handler);
        }
        
        public void UnListen(int eventType, EventHandler handler)
        {
            if (_handlers.TryGetValue(eventType, out var list))
            {
                list.Remove(handler);
            }
        }

        private readonly List<EventHandler> _temp = new();
        
        public void Fire(int eventType, object param)
        {
            if (_handlers.TryGetValue(eventType, out var list))
            {
                _temp.Clear();
                _temp.AddRange(list);
                foreach (var handler in _temp)
                {
                    handler?.Invoke(eventType, param);
                }
            }
        }
    }
}