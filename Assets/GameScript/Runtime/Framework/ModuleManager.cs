using System;
using System.Collections.Generic;

namespace GameScript.Runtime.Framework
{
    public interface IModule
    {
        void Initialize();
        void Dispose();
    }
    
    public class ModuleManager : Singleton<ModuleManager>
    {
        private readonly Dictionary<Type, IModule> _modules = new();

        public void Initialize()
        {
        }

        public void Clear()
        {
            foreach (var module in _modules.Values)
            {
                module.Dispose();
            }
        }

        public IModule RetrieveModule(Type type)
        {
            return _modules.GetValueOrDefault(type);
        }

    }
}