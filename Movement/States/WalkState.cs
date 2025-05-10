using MainGame.Scripts.FSM;
using UnityEngine;

namespace Assets.MainGame.Scripts.Movement.States
{
    public class WalkState : MovementBase
    {
        public WalkState(FSM fsm, float speed, InputSystem inputSystem, Rigidbody rb, float jumpForce, Transform transform) 
            : base(fsm, speed, inputSystem, rb, jumpForce, transform)
        {
            
        }
        public override void Enter()
        {
            Debug.Log("Enter [WALK]");
            _inputSystem.Player.Jump.performed += Jump;
        }
        public override void Update()
        {
            Move();
            if (!_inputSystem.Player.Move.IsPressed()) 
            {
                _fsm.SetState<IdleState>();
            }
            if (_inputSystem.Player.Sprint.IsPressed())
            {
                _fsm.SetState<RunState>();
            }

        }
         
        public override void Exit() 
        {
            Debug.Log("Exit [WALK]");
            _inputSystem.Player.Jump.performed -= Jump;
        }
    }
}
