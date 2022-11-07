using System;
using UnityEngine;

namespace Game.BodyComponents
{
    [Serializable]
    public struct PartsAssotioation
    {
        [SerializeField] private Transform _menuPrefab;
        [SerializeField] private Transform _fightingPrefab;

        public Transform MenuPrefab => _menuPrefab;
        public Transform FightingPrefab => _fightingPrefab;
    }
}
