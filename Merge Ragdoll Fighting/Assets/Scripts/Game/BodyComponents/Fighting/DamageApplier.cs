using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.BodyComponents.Fighting
{
    [RequireComponent(typeof(Rigidbody))]
    public class DamageApplier : MonoBehaviour
    {
        [SerializeField] private Body _body;

        [Space(30)]
        [Header("Required Components:")]
        [Space(5)]
        [SerializeField] private Rigidbody _rigidbody;

        public Rigidbody Rigidbody => _rigidbody;

        [Button]
        private void SetRequiredComponents()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void ApplyDamage(int damage)
        {
            _body.ApplyDamage(damage);
        }
    }
}