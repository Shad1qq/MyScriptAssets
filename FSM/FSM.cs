using System.Collections.Generic;
using System;

namespace MainGame.Scripts.FSM
{
    public class FSM
    {
        private FSMState CurrentState { get; set; }
        private Dictionary<Type, FSMState> _states = new Dictionary<Type, FSMState>();

        public void SetState<T>() where T : FSMState
        {
            var type = typeof(T);

            if (_states.TryGetValue(type, out var newState))
            {
                CurrentState?.Exit();
                CurrentState = newState;
                CurrentState.Enter();
            }
        }
        public void AddState(FSMState newState)
        {
            _states.Add(newState.GetType(), newState);
        }
        public void Update()
        {
            CurrentState?.Update();
        }
    }
}