using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;
using IJunior.TypedScenes;
using Game.BodyComponents;
using Game.BodyComponents.Menu;

namespace Game.SceneTransitions
{
    public class GameStarter : MonoBehaviour
    {
        [SerializeField] private PartsAssociator _partsAssociator;
        [SerializeField] private GameObject _changersRoot;

        [Space(30)]
        [SerializeField] private MenuPartsChanger[] _partsChangers;

        private List<BodyPartType> _requiredTypes = Enum.GetValues(typeof(BodyPartType)).Cast<BodyPartType>().ToList();

#if UNITY_EDITOR
        [Button]
        private void SetComponentsFromRoot()
        {
            _partsChangers = _changersRoot.GetComponentsInChildren<MenuPartsChanger>(_changersRoot);
        }
#endif

        public void StartGame()
        {
            var bodyParts = CreateBodyParts(_partsChangers, _partsAssociator);

            Fighting.Load(bodyParts.ToArray());
        }

        public void SelectPart(BodyPartType type)
        {
            _requiredTypes.Remove(type);

            if (_requiredTypes.Count == 0)
            {
                gameObject.SetActive(true);
            }
        }

        private BodyPart[] CreateBodyParts(PartsChanger[] partsChangers, PartsAssociator associator)
        {
            var bodyParts = new List<BodyPart>();

            foreach (var changer in partsChangers)
            {
                var fightingPrefab = associator.GetFightingPrefab(changer.Prefab);
                var part = new BodyPart(changer.BodyPartType, fightingPrefab);

                bodyParts.Add(part);
            }

            return bodyParts.ToArray();
        }
    }
}