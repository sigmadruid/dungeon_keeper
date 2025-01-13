using System.Collections.Generic;

namespace GameScript.Runtime.Framework
{
    public class StateMachine
    {
        private readonly Dictionary<int, State> _states = new();
        private State _currentState;
        private Blackboard _blackboard;

        public void Initialize(Blackboard blackboard)
        {
            _blackboard = blackboard;
        }

        public void Dispose()
        {
            _currentState?.OnExit();
            _states.Clear();
            _blackboard.Dispose();
        }

        public void Update()
        {
            _currentState?.OnUpdate();
        }

        public void Add(State state)
        {
            _states.TryAdd(state.ID, state);
        }

        public State Get(int stateID)
        {
            return _states.GetValueOrDefault(stateID);
        }

        public void Goto(int stateID)
        {
            _currentState?.OnExit();
            _currentState = Get(stateID);
            _currentState?.OnEnter();
        }
    }
}