using UnityEngine;
using Game.BodyComponents.Fighting;

namespace Game.EnemyComponents
{
    public class EnemyIntelligence : MonoBehaviour
    {
        [SerializeField] private Body _body;
        [SerializeField] private float _curvePassingDuration;
        [SerializeField] private AnimationCurve[] _movementCurves;

        private AnimationCurve _movementCurve;
        private float _curveProgress;

        private void Start()
        {
            var randomIndex = Random.Range(0, _movementCurves.Length);

            _movementCurve = _movementCurves[randomIndex];
        }

        private void Update()
        {
            if (_curveProgress < 1)
            {
                _curveProgress += Time.deltaTime / _curvePassingDuration;
            }

            var speedCoeficcient = _movementCurve.Evaluate(_curveProgress);

            _body.SetMovementSpeed(speedCoeficcient);
        }
    }
}