using UnityEngine;

namespace Roman.PlanetTest
{
    public class CameraMovement : MonoBehaviour
    {
        [SerializeField] private Transform _playerTransform;

        [SerializeField] private Vector3 _offsetPosition = new Vector3(0, 5, 5);
        [SerializeField] private bool _lookAt = true;

        private Transform _mainCam = null;

        private void Start()
        {
            if (_playerTransform == null)
            {
                Debug.LogError("CameraMovement is missing playerTransform");
            }
            else
            {
                _mainCam = Camera.main.transform;
            }
        }

        private void LateUpdate()
        {
            UpdateCamera();
        }

        private void UpdateCamera()
        {
            if (_playerTransform == null)
            {
                return;
            }
            transform.position = _playerTransform.position + -(_playerTransform.forward * _offsetPosition.z) + (_playerTransform.up * _offsetPosition.y);
            if (_lookAt)
            {
                _mainCam.LookAt(_playerTransform, _playerTransform.up);
            }
            else
            {
                _mainCam.LookAt(_playerTransform);
            }
        }
    }
}