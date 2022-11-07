using UnityEngine;
using IJunior.TypedScenes;

namespace Assets.Scripts.Game.SceneTransitions
{
    public class MenuStarter : MonoBehaviour
    {
        public void GoToMenu()
        {
            Menu.Load();
        }
    }
}