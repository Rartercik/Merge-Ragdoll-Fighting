using UnityEngine;
using Zenject;
using Game.Utilities;

namespace Game.BodyComponents.Fighting
{
    public class FightingPartsChanger : PartsChanger
    {
        [SerializeField] private Body _body;
        [SerializeField] private Transform _partLocation;

        private Decorator<DiContainer> _containerDecorator;

        [Inject]
        public void Construct(Decorator<DiContainer> containerDecorator)
        {
            _containerDecorator = containerDecorator;
        }

        protected override Transform CreatePart(Transform prefab)
        {
            var position = _partLocation.position;
            var rotation = _partLocation.rotation * prefab.rotation;

            return _containerDecorator.Value.InstantiatePrefab(prefab, position, rotation, _partLocation).transform;
        }

        protected override void DoOnChangedActions()
        {
            _body.AddLimb(CurrentPart);
        }
    }
}
