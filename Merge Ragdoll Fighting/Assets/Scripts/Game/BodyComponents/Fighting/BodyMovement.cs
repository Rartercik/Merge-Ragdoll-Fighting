using UnityEngine;
using Animancer;

namespace Game.BodyComponents.Fighting
{
    public class BodyMovement : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private HybridAnimancerComponent _animancer;
        [SerializeField] private float _speed;

        private readonly string _movementSpeedName = "MovementSpeed";

        public void SetMovementSpeed(float coefficient)
        {
            coefficient = Mathf.Clamp(coefficient, -1, 1);
            var finalSpeed = _speed * coefficient;

            _animancer.SetFloat(_movementSpeedName, finalSpeed);
        }
    }
}