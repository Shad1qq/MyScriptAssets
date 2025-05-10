using Assets.MainGame.Scripts.Movement.States;
using MainGame.Scripts.FSM;
using UnityEngine;

public class CrouchState : MovementBase
{
    public CrouchState(FSM fsm, float crouchspeed, InputSystem inputSystem, Rigidbody rb) : base(fsm, crouchspeed, inputSystem, rb)
    {
    }

    public override void Enter()
    {
        Crouch();
    }
    public override void Update()
    {
        Move();
        if (!_inputSystem.Player.Crouch.IsPressed())
        {
            _fsm.SetState<IdleState>();
        }
    }
    public override void Exit() 
    {
        StandUp();
    }
}
