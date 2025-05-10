using Assets.MainGame.Scripts.Movement.States;
using MainGame.Scripts.FSM;
using UnityEngine;

public class AirState : MovementBase
{
    private float _maxDistance;
    public AirState(FSM fsm, float speed,  InputSystem inputSystem, Rigidbody rb, Transform transform, float maxDistance) : base(fsm, speed, inputSystem, rb)
    {
        _transform = transform;
        _maxDistance = maxDistance;
    }
    public override void Enter()
    {
        Debug.Log("You In Air");
    }
    public override void Update()
    {
        Move();
        bool hit = Physics.Raycast(_transform.position, Vector3.down, _maxDistance, 1<<6);
        if(hit)
        {
            _fsm.SetState<WalkState>();
        }
    }
    public override void Exit() 
    {
        Debug.Log("You On Ground");
    }
}
