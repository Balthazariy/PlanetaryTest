using UnityEngine;

namespace Roman.PlanetTest
{
    public class EnemySphereMovement : MonoBehaviour
    {
        [SerializeField] private float _speed = 5.0f;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private Transform _player;

        [SerializeField] private float _avoidanceDistance = 2.0f;
        [SerializeField] private float _castRadius = 1.0f;
        [SerializeField] private LayerMask _obstacleLayer;
        [SerializeField] private float _followDistance = 1.0f;

        private void Update()
        {
            Vector3 playerDirection = (_player.position - transform.position).normalized;

            float distanceToPlayer = Vector3.Distance(transform.position, _player.position);

            Vector3 avoidanceDirection = AvoidanceDirection();

            if (distanceToPlayer < _followDistance)
            {
                Vector3 moveDirection = (playerDirection + avoidanceDirection).normalized;

                _rigidbody.MovePosition(_rigidbody.position + (moveDirection * _speed * Time.deltaTime));

                Quaternion targetRotation = Quaternion.LookRotation(playerDirection);
                _rigidbody.MoveRotation(targetRotation);
            }
            else
            {
                _rigidbody.velocity = Vector3.zero;
            }
        }

        private Vector3 AvoidanceDirection()
        {
            RaycastHit hit;
            Vector3 avoidanceDirection = Vector3.zero;

            if (Physics.SphereCast(transform.position, _castRadius, transform.forward, out hit, _avoidanceDistance, _obstacleLayer))
            {
                avoidanceDirection = Vector3.Reflect(transform.forward, hit.normal);
            }

            return avoidanceDirection;
        }
    }
}