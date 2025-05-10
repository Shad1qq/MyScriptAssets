using MainGame.Scripts.FSM;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.MainGame.Scripts.Movement.States
{
    public abstract class MovementBase : FSMState
    {
        protected Rigidbody _rb;
        protected float _speed;
        protected InputSystem _inputSystem;
        protected float _jumpForce;
        protected Transform _transform;

        #region Constructors
        public MovementBase(FSM fsm, float speed, InputSystem inputSystem, Rigidbody rb) : base(fsm)
        {
            _speed = speed;
            _inputSystem = inputSystem;
            _rb = rb;
        }
        public MovementBase(FSM fsm, InputSystem inputSystem, Rigidbody rb) : base(fsm)
        {   
            _inputSystem = inputSystem;
            _rb = rb;
        }
        public MovementBase(FSM fsm, float speed, InputSystem inputSystem, Rigidbody rb, float jumpForce, Transform transform) : base(fsm)
        {
            _inputSystem = inputSystem;
            _rb = rb;
            _jumpForce = jumpForce;
            _speed = speed;
            _transform = transform;
        }

        #endregion
        protected void Move()
        {
            Vector3 direction = _inputSystem.Player.Move.ReadValue<Vector3>();
            Vector3 worldPos = _transform.TransformDirection(direction) * _speed;
            _rb.linearVelocity = new Vector3(worldPos.x, _rb.linearVelocity.y, worldPos.z);
        }
        protected void Jump(InputAction.CallbackContext obj)
        {
            _rb.AddForce(Vector3.up*_jumpForce, ForceMode.Impulse);
            _fsm.SetState<AirState>();
        }
        protected void Crouch()
        {
            _rb.transform.localScale = new Vector3(_rb.transform.localScale.x, 0.5f, _rb.transform.localScale.z);
        }
        protected void StandUp()
        {
            _rb.transform.localScale = new Vector3(_rb.transform.localScale.x, 1f, _rb.transform.localScale.z);
        }

    }
}
