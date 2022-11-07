using UnityEngine;

namespace Game.BodyComponents
{
    public abstract class PartsChanger : MonoBehaviour
    {
        [field: SerializeField] public BodyPartType BodyPartType { get; protected set; }

        private Transform _currentPart;

        public Transform Prefab { get; private set; }
        public Transform CurrentPart => _currentPart;

        public void Change(Transform prefab)
        {
            Prefab = prefab;

            if (_currentPart != null)
            {
                Destroy(_currentPart.gameObject);
            }

            _currentPart = CreatePart(prefab);

            DoOnChangedActions();
        }

        protected abstract Transform CreatePart(Transform prefab);

        protected abstract void DoOnChangedActions();
    }
}