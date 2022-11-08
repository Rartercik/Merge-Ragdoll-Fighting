using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game.BodyComponents.Fighting
{
    [RequireComponent(typeof(Rigidbody))]
    public class Bullet : HittingObject
    {
        [SerializeField] private float _speed;

        [Space(30)]
        [Header("Required Components:")]
        [Space(5)]
        [SerializeField] private Transform _transform;
        [SerializeField] private Rigidbody _rigidbody;

        private Transform _enemyTransform;

#if UNITY_EDITOR
        [Button]
        private void SetRequiredComponents()
        {
            _transform = transform;
            _rigidbody = GetComponent<Rigidbody>();
        }
#endif

        [Inject]
        private void Construct(Transform enemy, Vector3 hitDimensions, LayerMask enemyLayer)
        {
            _enemyTransform = enemy;
            HitDimensions = hitDimensions;
            Enemy = enemyLayer;
        }

        protected override Vector3 HitDimensions { get; set; }
        protected override LayerMask Enemy { get; set; }
        protected override bool AdditionalHitCondition => true;

        protected override void DoOnHitActions()
        {
            Destroy(gameObject);
        }

        private void Start()
        {
            _transform.SetParent(null);
        }

        private void Update()
        {
            var directionToEnemy = (_enemyTransform.position - _transform.position).normalized;
            _rigidbody.velocity = directionToEnemy * _speed;
        }
    }
}