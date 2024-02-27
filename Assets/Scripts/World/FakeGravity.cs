using UnityEngine;

namespace Roman.PlanetTest
{
    public class FakeGravity : MonoBehaviour
    {
        [SerializeField] private float _gravity = -10;

        [SerializeField] private float _size = 10;

        private string _worldObjectTag = "World";

        private float _objRotSpeed = 50;
        private float _gravityBoost = 0;

        public float WorldSize
        { get { return _size; } }

        private void Awake()
        {
            gameObject.tag = _worldObjectTag;
        }

        public void Attract(Transform objBody)
        {
            Vector3 gravityDir = (objBody.position - transform.position).normalized;
            Vector3 bodyUp = objBody.up;
            objBody.GetComponent<Rigidbody>().AddForce(gravityDir * (_gravity + _gravityBoost));
            Quaternion targetRotation = Quaternion.FromToRotation(bodyUp, gravityDir) * objBody.rotation;
            objBody.rotation = Quaternion.Slerp(objBody.rotation, targetRotation, _objRotSpeed * Time.deltaTime);
        }

        public void IncreaseGravity(bool increaseGravity, float amount)
        {
            if (increaseGravity)
            {
                _gravityBoost = _gravity * amount;
            }
            else
            {
                _gravityBoost = 0;
            }
        }
    }
}