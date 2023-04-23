using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CrossoverGame.ScriptableObjects;

namespace CrossoverGame.Components
{
    public class OrbitHandler : MonoBehaviour
    {
        /*
        * This is a component that handles an orbit behaviour between the attached GameObject and another one given to this
        */
        [SerializeField]
        private ConstantsScriptableObject _constants;

        [SerializeField]
        private Transform _target;

        private float _rotationY;
        private float _rotationX;

        private Vector3 _currentRotation;
        private Vector3 _smoothVelocity = Vector3.zero;

        private void Start() => StartCoroutine(ChangePosition(_target.position - transform.forward * _constants.distanceFromTarget, 0.1f, transform.position));

        /// <summary>
        /// This method set the focused object and lerps the position of the attached GameObject towards the target
        /// </summary>
        public void SetFocus(Transform stackTarget)
        {
            _target = stackTarget;
            StartCoroutine(ChangePosition(_target.position - transform.forward * _constants.distanceFromTarget,0.8f,transform.position));
        }

        private IEnumerator ChangePosition(Vector3 targetPosition, float duration, Vector3 startPosition)
        {
            float time = 0;
            while (time < duration)
            {
                transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
                time += Time.deltaTime;
                yield return null;
            }
            transform.position = targetPosition;
        }

        void Update()
        {
            if (Input.GetMouseButton(1))
            {
                float mouseX = Input.GetAxis("Mouse X") * _constants.mouseSensitivity;
                float mouseY = Input.GetAxis("Mouse Y") * _constants.mouseSensitivity;

                _rotationY += mouseX;
                _rotationX += mouseY;

                _rotationX = Mathf.Clamp(_rotationX, _constants.rotationXMinMax.x, _constants.rotationXMinMax.y);

                Vector3 nextRotation = new Vector3(_rotationX, _rotationY);

                _currentRotation = Vector3.SmoothDamp(_currentRotation, nextRotation, ref _smoothVelocity, _constants.smoothTime);
                transform.localEulerAngles = _currentRotation;

                transform.position = _target.position - transform.forward * _constants.distanceFromTarget;
            }
        }
    }
}
