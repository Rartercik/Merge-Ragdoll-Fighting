using Sirenix.OdinInspector;
using UnityEngine;
using Game.Tools;

namespace Game.Environment
{
    public class Pursuer : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private Vector3 _movingDementions;

        [Space(30)]
        [Header("Required Components:")]
        [Space(5)]
        [SerializeField] private Transform _transform;

        private Vector3 _startPosition;
        private Vector3 _startPositionOfTarget;

#if UNITY_EDITOR
        [Button]
        private void SetRequiredComponents()
        {
            _transform = transform;
        }
#endif

        private void Start()
        {
            _startPosition = _transform.position;
            _startPositionOfTarget = _target.position;
        }

        private void LateUpdate()
        {
            SetTargetPosition();
        }

        private void SetTargetPosition()
        {
            var offset = _target.position - _startPositionOfTarget;

            _transform.position = _startPosition + VectorTools.GetPermissibleVector(_movingDementions, offset);
        }
    }
}