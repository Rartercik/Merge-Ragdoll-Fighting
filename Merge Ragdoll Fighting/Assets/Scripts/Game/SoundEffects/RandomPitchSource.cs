using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.SoundEffects
{
    [RequireComponent(typeof(AudioSource))]
    public class RandomPitchSource : MonoBehaviour
    {
        [SerializeField] private AudioClip _shot;
        [SerializeField] private float _minPitch;
        [SerializeField] private float _maxPitch;

        [Space(30)]
        [Header("Required Components:")]
        [Space(5)]
        [SerializeField] private AudioSource _source;

        [Button]
        private void SetRequiredComponents()
        {
            _source = GetComponent<AudioSource>();
        }

        public void PlayOneShot()
        {
            _source.pitch = Random.Range(_minPitch, _maxPitch);
            _source.PlayOneShot(_shot);
        }
    }
}