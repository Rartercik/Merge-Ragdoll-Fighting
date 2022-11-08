using System;
using System.Collections;
using Sirenix.OdinInspector;
using UnityEngine;
using RootMotion.Dynamics;
using Zenject;
using Game.SoundEffects;
using Game.Tools;
using Game.Utilities;

namespace Game.BodyComponents.Fighting
{
    [RequireComponent(typeof(RandomPitchSource))]
    public class Gun : MonoBehaviour
    {
        [SerializeField] private Transform _shootLocation;
        [SerializeField] private Transform _bulletPrefab;
        [SerializeField] private float _shootingRate;

        [Space(30)]
        [Header("Required Components:")]
        [Space(5)]
        [SerializeField] private Transform _transform;
        [SerializeField] private RandomPitchSource _shotSoundSource;

        private Decorator<DiContainer> _containerDecorator;
        private PuppetMaster _body;
        private Animator _hitAnimator;
        private AnimationClip _hitAnimation;

        private bool _startedAttacking;
        private bool _attacking;

#if UNITY_EDITOR
        [Button]
        private void SetRequiredComponents()
        {
            _transform = transform;
            _shotSoundSource = GetComponent<RandomPitchSource>();
        }
#endif

        [Inject]
        public void Construct(Decorator<DiContainer> containerDecorator, PuppetMaster body, Animator hitAnimator, AnimationClip hitAnimation)
        {
            if (hitAnimator.Contains(hitAnimation) == false)
            {
                throw new ArgumentException("Animator should contain your animation");
            }

            _containerDecorator = containerDecorator;
            _body = body;
            _hitAnimator = hitAnimator;
            _hitAnimation = hitAnimation;
        }

        private void Start()
        {
            _body.OnDeath += () => _attacking = false;
            StartCoroutine(ShootAfter(_shootingRate));
        }

        private void Update()
        {
            if (_hitAnimator.IsPlaying(_hitAnimation) && _startedAttacking == false)
            {
                _startedAttacking = true;
                _attacking = true;
            }
        }

        private IEnumerator ShootAfter(float seconds)
        {
            yield return new WaitForSeconds(seconds);

            if (_attacking)
            {
                Shoot();
            }

            StartCoroutine(ShootAfter(seconds));
        }

        private void Shoot()
        {
            _shotSoundSource.PlayOneShot();
            _containerDecorator.Value.InstantiatePrefab(_bulletPrefab, _shootLocation.position, Quaternion.identity, _transform);
        }
    }
}
