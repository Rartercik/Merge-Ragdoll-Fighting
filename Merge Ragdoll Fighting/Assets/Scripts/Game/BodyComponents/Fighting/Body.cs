using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.BodyComponents.Fighting
{
    [RequireComponent(typeof(BodyMovement))]
    [RequireComponent(typeof(BodyInteraction))]
    public class Body : MonoBehaviour
    {
        [Header("Required Components:")]
        [Space(5)]
        [SerializeField] private BodyMovement _movement;
        [SerializeField] private BodyInteraction _interaction;

#if UNITY_EDITOR
        [Button]
        private void SetRequiredComponents()
        {
            _movement = GetComponent<BodyMovement>();
            _interaction = GetComponent<BodyInteraction>();
        }
#endif

        public void SetMovementSpeed(float coefficient)
        {
            _movement.SetMovementSpeed(coefficient);
        }

        public void AddLimb(Transform limb)
        {
            _interaction.AddLimb(limb);
        }

        public void MakeUndying()
        {
            _interaction.MakeUndying();
        }

        public void ApplyDamage(int damage)
        {
            _interaction.ApplyDamage(damage);
        }
    }
}