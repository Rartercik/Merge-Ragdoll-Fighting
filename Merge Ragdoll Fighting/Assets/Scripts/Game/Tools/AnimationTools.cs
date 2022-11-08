using UnityEngine;

namespace Game.Tools
{
    public static class AnimationTools
    {
        public static bool Contains(RuntimeAnimatorController animator, AnimationClip targetClip)
        {
            var clips = animator.animationClips;

            foreach (var clip in clips)
            {
                if (clip == targetClip)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
