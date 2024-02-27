using UnityEngine;

namespace Roman.PlanetTest
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _speed = 10.0f;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private Transform _model;
        [SerializeField] private Joystick _joystick;

        private Vector3 _moveDirection;

        private void Update()
        {
            _moveDirection = new Vector3(_joystick.Horizontal, 0, _joystick.Vertical).normalized;

            RotateForward();
        }

        private void FixedUpdate()
        {
            _rigidbody.MovePosition(_rigidbody.position + transform.TransformDirection(_moveDirection * _speed * Time.deltaTime));
        }

        private void RotateForward()
        {
            Vector3 dir = _moveDirection;
            float angle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.up);
            if (Vector3.Magnitude(dir) > 0.0f)
            {
                _model.localRotation = targetRotation;
            }
        }
    }
}