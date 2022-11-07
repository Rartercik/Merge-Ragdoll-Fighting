using System.Linq;
using UnityEngine;

namespace Game.BodyComponents
{
    [CreateAssetMenu]
    public class PartsAssociator : ScriptableObject
    {
        [SerializeField] private PartsAssotioation[] _assotioations;

        public Transform GetMenuPrefab(Transform fightingPrefab)
        {
            return _assotioations.First(assotioation => assotioation.FightingPrefab == fightingPrefab).MenuPrefab;
        }

        public Transform GetFightingPrefab(Transform menuPrefab)
        {
            return _assotioations.First(assotioation => assotioation.MenuPrefab == menuPrefab).FightingPrefab;
        }
    }
}