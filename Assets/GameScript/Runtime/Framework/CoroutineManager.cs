using System.Collections;
using UnityEngine;

namespace GameScript.Runtime.Framework
{
    public class CoroutineBehaviour : MonoBehaviour
    {
        
    }
    
    public class CoroutineManager : Singleton<CoroutineManager>
    {
        private CoroutineBehaviour _behaviour;
        
        public void Initialize()
        {
            _behaviour = new GameObject("CoroutineManager").AddComponent<CoroutineBehaviour>();
            Object.DontDestroyOnLoad(_behaviour.gameObject);
        }
        
        public void Dispose()
        {
            if (_behaviour)
            {
                Object.Destroy(_behaviour.gameObject);
                _behaviour = null;
            }
        }

        public void StartCoroutine(IEnumerator enumerator)
        {
            _behaviour.StartCoroutine(enumerator);
        }
    }
}