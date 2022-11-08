using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;
using Game.BodyComponents.Menu;
using Game.SoundEffects;

namespace Game.MenuComponents
{
    [RequireComponent(typeof(Button))]
    [RequireComponent(typeof(RandomPitchSource))]
    public class PartPanel : MonoBehaviour
    {
        [SerializeField] private int _indificator;
        [SerializeField] private MenuPartsChanger[] _partsChangers;
        [SerializeField] private Transform _menuPrefab;
        [SerializeField] private Sprite _availableSprite;
        [SerializeField] private Sprite _blockedSprite;

        [Space(30)]
        [Header("Required Components:")]
        [Space(5)]
        [SerializeField] private Image _image;
        [SerializeField] private RandomPitchSource _changeSoundSource;

        private bool _blocked = true;

#if UNITY_EDITOR
        [Button]
        private void SetRequiredComponents()
        {
            _image = GetComponent<Image>();
            _changeSoundSource = GetComponent<RandomPitchSource>();
        }
#endif

        public int Indificator => _indificator;

        public void Block()
        {
            _image.sprite = _blockedSprite;
            _blocked = true;
        }

        public void Unblock()
        {
            _image.sprite = _availableSprite;
            _blocked = false;
        }

        public void TryChoose()
        {
            if (_blocked) return;

            foreach (var partsChanger in _partsChangers)
            {
                partsChanger.Change(_menuPrefab);
            }

            _changeSoundSource.PlayOneShot();
        }
    }
}
