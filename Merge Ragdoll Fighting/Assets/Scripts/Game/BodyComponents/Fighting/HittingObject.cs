using Sirenix.OdinInspector;
using UnityEngine;
using Game.Tools;

namespace Game.BodyComponents.Fighting
{
    [RequireComponent(typeof(Collider))]
    public abstract class HittingObject : MonoBehaviour
    {
        [SerializeField] private int _hitDamage;
        [SerializeField] private float _hitForce;

        [Space(30)]
        [Header("Required Components:")]
        [Space(5)]
        [SerializeField] private Collider _collider;

        [Button]
        private void SetRequiredComponents()
        {
            _collider = GetComponent<Collider>();
        }

        protected abstract Vector3 HitDimensions { get; set; }
        protected abstract LayerMask Enemy { get; set; }
        protected abstract bool AdditionalHitCondition { get; }

        private void Start()
        {
            HitDimensions.Normalize();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (LayerTools.EqualLayers(Enemy, other.gameObject.layer) && AdditionalHitCondition)
            {
                if (other.TryGetComponent(out DamageApplier enemy))
                {
                    Hit(enemy, other);
                    DoOnHitActions();
                }
            }
        }

        protected abstract void DoOnHitActions();

        private void Hit(DamageApplier enemy, Collider enemyPart)
        {
            enemy.ApplyDamage(_hitDamage);
            AddForceTo(enemy, enemyPart);
        }

        private void AddForceTo(DamageApplier enemy, Collider enemyPart)
        {
            var detectorPosition = _collider.bounds.center;
            var hitPosition = enemyPart.ClosestPointOnBounds(detectorPosition);
            var hitForce = HitDimensions * _hitForce;

            enemy.Rigidbody.AddForceAtPosition(hitForce, hitPosition, ForceMode.VelocityChange);
        }
    }
}