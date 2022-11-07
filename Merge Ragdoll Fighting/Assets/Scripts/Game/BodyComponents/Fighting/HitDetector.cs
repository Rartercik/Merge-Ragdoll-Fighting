using System;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;
using Game.SoundEffects;
using Game.Tools;

namespace Game.BodyComponents.Fighting
{
    [RequireComponent(typeof(RandomPitchSource))]
    public class HitDetector : HittingObject
    {
        private Animator _hitAnimator;
        private AnimationClip _hitAnimation;

        [Space(30)]
        [Header("Required Components:")]
        [Space(5)]
        [SerializeField] private RandomPitchSource _hitSoundSource;

        private bool _canAttack = true;

        [Button]
        private void SetRequiredComponents()
        {
            _hitSoundSource = GetComponent<RandomPitchSource>();
        }

        [Inject]
        private void Construct(Vector3 hitDimensions, Animator hitAnimator, AnimationClip hitAnimation, LayerMask enemy)
        {
            if (hitAnimator.Contains(hitAnimation) == false)
            {
                throw new ArgumentException("Animator should contain your animation");
            }

            HitDimensions = hitDimensions;
            _hitAnimator = hitAnimator;
            _hitAnimation = hitAnimation;
            Enemy = enemy;
        }

        protected override Vector3 HitDimensions { get; set; }
        protected override LayerMask Enemy { get; set; }
        protected override bool AdditionalHitCondition => _hitAnimator.IsPlaying(_hitAnimation) && _canAttack;

        public AnimationClip AnimationClip => _hitAnimation;

        protected override void DoOnHitActions()
        {
            _hitSoundSource.PlayOneShot();
            _canAttack = false;
        }

        public void SetAttackAvailable()
        {
            _canAttack = true;
        }
    }
}