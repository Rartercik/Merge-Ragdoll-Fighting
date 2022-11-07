using System;
using UnityEngine;

namespace Game.BodyComponents
{
    [Serializable]
    public struct BodyPart
    {
        [SerializeField] private BodyPartType _type;
        [SerializeField] private Transform _prefab;

        public BodyPartType Type => _type;
        public Transform Prefab => _prefab;

        public BodyPart(BodyPartType type, Transform prefab)
        {
            _type = type;
            _prefab = prefab;
        }
    }
}
