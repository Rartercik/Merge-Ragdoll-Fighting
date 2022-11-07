using UnityEngine;
using Game.SceneTransitions;

namespace Game.BodyComponents.Menu
{
    public class MenuPartsChanger : PartsChanger
    {
        [SerializeField] private GameStarter _gameStarter;
        [SerializeField] private BodyPartType _bodyPartType;
        [SerializeField] private Transform _partLocation;

        protected override Transform CreatePart(Transform prefab)
        {
            var position = _partLocation.position;
            var rotation = _partLocation.rotation * prefab.rotation;

            return Instantiate(prefab, position, rotation, _partLocation);
        }

        protected override void DoOnChangedActions()
        {
            _gameStarter.SelectPart(BodyPartType);
        }
    }
}