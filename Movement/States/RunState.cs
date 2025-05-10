using Assets.MainGame.Scripts.Movement.States;
using MainGame.Scripts.FSM;
using UnityEngine;

public class RunState : MovementBase
{
    public RunState(FSM fsm, float runspeed, InputSystem inputSystem, Rigidbody rb, float jumpForce, Transform transform) : base(fsm, runspeed, inputSystem, rb, jumpForce, transform)
    {
    }
    public override void Update()
    {
        Move();
        if (!_inputSystem.Player.Sprint.IsPressed())
        {
            _fsm.SetState<WalkState>();
        }
    }
}
