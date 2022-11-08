using Sirenix.OdinInspector;
using UnityEngine;
using Game.Tools;

namespace Game.Environment
{
    public class CameraMovement : MonoBehaviour
    {
        [SerializeField] private Transform _player;
        [SerializeField] private Transform _enemy;
        [SerializeField] private Vector3 _movingDimensions;
        [SerializeField] private float _maxCharactersDistance;
        [SerializeField] private float _minDistanceFromCharacters;
        [SerializeField] private float _maxDistanceFromCharacters;

        [Space(30)]
        [Header("Required Components:")]
        [Space(5)]
        [SerializeField] private Transform _transform;

        private Vector3 _startPosition;
        private Vector3 _centerStartPosition;

        private void Start()
        {
            _startPosition = _transform.position;
            _centerStartPosition = GetCenter(_player.position, _enemy.position);
        }

#if UNITY_EDITOR
        [Button]
        private void SetRequiredComponents()
        {
            _transform = transform;
        }
#endif

        private void LateUpdate()
        {
            SetTargetPosition();
        }

        private void SetTargetPosition()
        {
            var center = GetCenter(_player.position, _enemy.position);

            var charactersDistance = Vector3.Distance(_player.position, _enemy.position);
            var position = VectorTools.GetPermissibleVector(_movingDimensions, _startPosition + center);
            position += GetOffset(_movingDimensions, _maxCharactersDistance, charactersDistance, _minDistanceFromCharacters, _maxDistanceFromCharacters);

            _transform.position = position;
        }

        private Vector3 GetOffset(Vector3 movingDimensions, float maxCharactersDistance, float charactersDistance, float minOffset, float maxOffset)
        {
            var clampedCharactersDistance = Mathf.Clamp(charactersDistance, 0, maxCharactersDistance);
            var charactersDistanceCoeficient = clampedCharactersDistance / maxCharactersDistance;
            var maxAbsOffset = Mathf.Max(Mathf.Abs(minOffset), Mathf.Abs(maxOffset));
            var maxOffsetWhenAbs = maxAbsOffset == Mathf.Abs(minOffset) ? minOffset : maxOffset;

            var offset = charactersDistanceCoeficient * maxOffsetWhenAbs;
            var clampedOffset = Mathf.Clamp(offset, minOffset, maxOffset);

            return GetBlockedDimensions(movingDimensions) * clampedOffset;
        }

        private Vector3 GetBlockedDimensions(Vector3 dimension)
        {
            var result = new Vector3();

            if (dimension.x == 0) result.x = 1;
            if (dimension.y == 0) result.y = 1;
            if (dimension.z == 0) result.z = 1;

            return result;
        }

        private Vector3 GetCenter(Vector3 point1, Vector3 point2)
        {
            return (point1 + point2) / 2;
        }
    }
}