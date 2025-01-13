namespace GameScript.Runtime.Framework
{
    public class State
    {
        public int ID { get; }

        protected Blackboard _blackboard;

        public void Initialize(Blackboard blackboard)
        {
            _blackboard = blackboard;
        }
        
        public void Dispose()
        {
            _blackboard = null;
        }
        
        public virtual void OnEnter()
        {
            
        }
        
        public virtual void OnExit()
        {
            
        }
        
        public virtual void OnUpdate()
        {
            
        }
    }
}