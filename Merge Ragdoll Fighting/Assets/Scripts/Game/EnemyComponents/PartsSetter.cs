using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;
using Game.BodyComponents;
using Game.Tools;

namespace Game.EnemyComponents
{
    public class PartsSetter : MonoBehaviour
    {
        [SerializeField] private Transform _changersRoot;
        [SerializeField] private BodyPart[] _typedPartPrefabs;

        [Space(30)]
        [SerializeField] private PartsChanger[] _partsChangers;

        [Button]
        private void SetComponentsFromRoot()
        {
            _partsChangers = _changersRoot.GetComponentsInChildren<PartsChanger>(_changersRoot);
        }

        private void Start()
        {
            var sortedParts = GetSortedParts(_typedPartPrefabs);
            var randomParts = GetEveryRandomPart(sortedParts);

            BodyTools.ChangeAll(_partsChangers, randomParts);
        }

        private BodyPart[][] GetSortedParts(BodyPart[] parts)
        {
            var result = new List<BodyPart[]>();
            var types = Enum.GetValues(typeof(BodyPartType)).Cast<BodyPartType>();

            foreach (var type in types)
            {
                var typedParts = parts.Where(part => part.Type == type).ToArray();
                result.Add(typedParts);
            }

            return result.ToArray();
        }

        private BodyPart[] GetEveryRandomPart(BodyPart[][] sortedParts)
        {
            var result = new List<BodyPart>();

            foreach (var typedParts in sortedParts)
            {
                var randomIndex = UnityEngine.Random.Range(0, typedParts.Length);
                result.Add(typedParts[randomIndex]);
            }

            return result.ToArray();
        }
    }
}