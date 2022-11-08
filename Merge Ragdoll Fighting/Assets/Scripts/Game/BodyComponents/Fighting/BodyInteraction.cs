using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;
using RootMotion.Dynamics;

namespace Game.BodyComponents.Fighting
{
    public class BodyInteraction : MonoBehaviour
    {
        [SerializeField] private PuppetMaster _puppetMaster;
        [SerializeField] private Rigidbody _mainRigidbody;
        [SerializeField] private Animator _animator;
        [SerializeField] private Transform _enemy;
        [SerializeField] private HPVisualizator _HPVisualizator;
        [SerializeField] private float _maxAttackDistance;
        [SerializeField] private int _HP;
        [SerializeField] private PartsChanger[] _partsChangers;
        [SerializeField] private UnityEvent _onDead;

        private readonly string _attackTrigger = "Attack";

        private List<HitDetector> _limbs = new List<HitDetector>();
        private bool _undying;
        private int _maxHP;

        [Space(30)]
        [Header("Required Components:")]
        [Space(5)]
        [SerializeField] private Transform _transform;

#if UNITY_EDITOR
        [Button]
        private void SetRequiredComponents()
        {
            _transform = transform;
        }
#endif

        private void Start()
        {
            _maxHP = _HP;
        }

        private void Update()
        {
            if (Vector3.Distance(_transform.position, _enemy.position) <= _maxAttackDistance)
            {
                _animator.SetTrigger(_attackTrigger);
            }
        }

        public void AddLimb(Transform limb)
        {
            var hitDetector = limb.GetComponentInChildren(typeof(HitDetector)) as HitDetector;

            if (limb != null)
            {
                _limbs.Add(hitDetector);
            }
        }

        public void MakeUndying()
        {
            _undying = true;
        }

        public void SetAttackAvailableBy(AnimationClip animation)
        {
            var limb = _limbs.Where(limb => limb != null).FirstOrDefault(limb => limb.AnimationClip == animation);

            if (limb != null)
            {
                limb.SetAttackAvailable();
            }
        }

        public void ApplyDamage(int damage)
        {
            if (damage < 0)
            {
                throw new ArgumentException("The damage must be positive");
            }

            if (_undying) return;

            ProcessDamage(damage);
            _HPVisualizator.Visualize(_HP, _maxHP);
        }

        private void ProcessDamage(int damage)
        {
            _HP -= damage;

            if (_HP <= 0)
            {
                _HP = 0;
                Die();
            }
        }

        private void Die()
        {
            _puppetMaster.state = PuppetMaster.State.Dead;
            _mainRigidbody.constraints = RigidbodyConstraints.None;

            _onDead.Invoke();
        }
    }
}