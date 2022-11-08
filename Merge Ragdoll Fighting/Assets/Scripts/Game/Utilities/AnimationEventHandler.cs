using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Utilities
{
    [RequireComponent(typeof(Animator))]
    public class AnimationEventHandler : MonoBehaviour
    {
        [SerializeField] private int _animatorLayerIndex;
        [SerializeField] private UnityEvent<AnimationClip> _event;

        [Space(30)]
        [Header("Required Components:")]
        [Space(5)]
        [SerializeField] private Animator _animator;

#if UNITY_EDITOR
        [Button]
        private void SetRequiredComponents()
        {
            _animator = GetComponent<Animator>();
        }
#endif

        public void HitAnimationEvent()
        {
            var stateInfo = _animator.GetCurrentAnimatorStateInfo(_animatorLayerIndex);
            var animations = _animator.GetCurrentAnimatorClipInfo(_animatorLayerIndex);

            var currentClip = GetCurrentClip(stateInfo, animations);

            _event?.Invoke(currentClip);
        }

        private AnimationClip GetCurrentClip(AnimatorStateInfo stateInfo, AnimatorClipInfo[] animations)
        {
            foreach (var animation in animations)
            {
                var clip = animation.clip;

                if (stateInfo.IsName(clip.name))
                {
                    return clip;
                }
            }

            return default(AnimationClip);
        }
    }
}