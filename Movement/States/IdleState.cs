using MainGame.Scripts.FSM;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.MainGame.Scripts.Movement.States
{
    public class IdleState : MovementBase
    {
        public IdleState(FSM fsm, InputSystem inputSystem, Rigidbody rb) : base(fsm, inputSystem, rb)
        {
            
        }
        public override void Enter()
        {
            Debug.Log("ENTER [IDLE]");
        }

        public override void Update() 
        {
            if (_inputSystem.Player.Move.IsPressed())
            {
                _fsm.SetState<WalkState>();
            }
            if (_inputSystem.Player.Crouch.IsPressed())
            {
                _fsm.SetState<CrouchState>();
            }
        }
        public override void Exit()
        {
            Debug.Log("Exit [IDLE]");
        }
    }
}
