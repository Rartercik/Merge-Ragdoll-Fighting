using UnityEngine;
using Game.BodyComponents.Fighting;

namespace Game.PlayerComponents
{
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] private Body _body;
        [SerializeField] private Joystick _joystick;

        private void Update()
        {
            var movementCoefficient = _joystick.Horizontal;

            _body.SetMovementSpeed(movementCoefficient);
        }
    }
}