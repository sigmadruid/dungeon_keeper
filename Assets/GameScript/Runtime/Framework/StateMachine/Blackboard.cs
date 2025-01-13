using System.Collections.Generic;

namespace GameScript.Runtime.Framework
{
    public class Blackboard
    {
        private readonly Dictionary<string, object> _data = new();

        public void Dispose()
        {
            _data.Clear();
        }

        public object Get(string key)
        {
            return _data.GetValueOrDefault(key);
        }

        public void Set(string key, object value)
        {
            _data.TryAdd(key, value);
        }
    }
}