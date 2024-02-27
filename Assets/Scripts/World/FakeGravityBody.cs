using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Roman.PlanetTest
{
    [RequireComponent(typeof(Rigidbody))]
    public class FakeGravityBody : MonoBehaviour
    {
        [SerializeField] private FakeGravity _attractor;

        private Transform _objTransform;
        private Rigidbody _objRigidbody;

        public FakeGravity Attractor
        { get { return _attractor; } set { _attractor = value; } }

        private void Start()
        {
            _objRigidbody = GetComponent<Rigidbody>();
            _objRigidbody.constraints = RigidbodyConstraints.FreezeRotation;
            _objRigidbody.useGravity = false;
            _objTransform = transform;
            if (_attractor == null)
            {
                _attractor = GameObject.FindGameObjectWithTag("World").GetComponent<FakeGravity>();
            }
        }

        private void Update()
        {
            if (_attractor != null)
            {
                _attractor.Attract(_objTransform);
            }
        }
    }
}