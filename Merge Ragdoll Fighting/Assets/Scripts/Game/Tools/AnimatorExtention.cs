using UnityEngine;

namespace Game.Tools
{
    public static class AnimatorExtention
    {
        public static bool Contains(this Animator animator, AnimationClip targetClip)
        {
            var clips = animator.runtimeAnimatorController.animationClips;

            foreach (var clip in clips)
            {
                if (clip == targetClip)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool IsPlaying(this Animator animator, AnimationClip animation)
        {
            var currentState = animator.GetCurrentAnimatorStateInfo(0);

            return currentState.IsName(animation.name);
        }
    }
}
