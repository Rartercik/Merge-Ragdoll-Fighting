using UnityEngine;
using Game.Economics;

namespace Game.Utilities
{
    public class Initializer : MonoBehaviour
    {
        [SerializeField] private PlayerPossesionsHandler _possesionsHandler;

        private void Awake()
        {
            _possesionsHandler.Initialize();
        }
    }
}