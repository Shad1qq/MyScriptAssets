using UnityEngine;

namespace MainGame.Scripts.FSM
{
    public abstract class FSMState
    {
        protected FSM _fsm;

        public FSMState(FSM fsm)
        {
            _fsm = fsm;
        }
        
        public virtual void Enter() {}
        public virtual void Update() {}
        public virtual void Exit() {}
    }
}