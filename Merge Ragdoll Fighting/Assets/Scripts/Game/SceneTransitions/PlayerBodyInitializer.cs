using Sirenix.OdinInspector;
using UnityEngine;
using IJunior.TypedScenes;
using Game.BodyComponents;
using Game.BodyComponents.Fighting;
using Game.Tools;

namespace Game.SceneTransitions
{
    public class PlayerBodyInitializer : MonoBehaviour, ISceneLoadHandler<BodyPart[]>
    {
        [SerializeField] private GameObject _changersRoot;

        [Space(30)]
        [SerializeField] private FightingPartsChanger[] _partsChangers;

        private BodyPart[] _parts;

        [Button]
        private void SetComponentsFromRoot()
        {
            _partsChangers = _changersRoot.GetComponentsInChildren<FightingPartsChanger>(_changersRoot);
        }

        private void Start()
        {
            BodyTools.ChangeAll(_partsChangers, _parts);
        }

        public void OnSceneLoaded(BodyPart[] parts)
        {
            _parts = parts;
        }
    }
}