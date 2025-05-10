using Assets.MainGame.Scripts.Movement.States;
using MainGame.Scripts.FSM;
using UnityEngine;
using Zenject;

namespace Assets.MainGame.Scripts.Movement
{
    [RequireComponent(typeof(Rigidbody))]
    public class Controller:MonoBehaviour
    {
        private FSM _fsm;
        private InputSystem _inputSystem;
        [SerializeField]private Rigidbody _rb;

        [SerializeField] private float _speed = 4f;
        [SerializeField] private float _crouchSpeed = 2f;
        [SerializeField] private float _sprintSpeed = 7f;
        [SerializeField] private float _maxRayDistance = 4f;
        [SerializeField] private float _jumpForce = 4f;

        [Inject]
        private void Constructor(FSM fsm, InputSystem inputActions)
        {
            _fsm = fsm;
            _inputSystem = inputActions;
        }
        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }

        private void Start()
        {   
            _fsm.AddState(new IdleState(_fsm, _inputSystem, _rb));
            _fsm.AddState(new WalkState(_fsm, _speed, _inputSystem, _rb, _jumpForce, transform));
            _fsm.AddState(new AirState(_fsm,_speed, _inputSystem, _rb, transform, _maxRayDistance));
            _fsm.AddState(new CrouchState(_fsm, _crouchSpeed, _inputSystem, _rb));
            _fsm.AddState(new RunState(_fsm, _sprintSpeed, _inputSystem, _rb, _jumpForce, transform));

            _fsm.SetState<IdleState>();   
        }
        private void Update() 
        {
            _fsm.Update();
        }
    }
}
