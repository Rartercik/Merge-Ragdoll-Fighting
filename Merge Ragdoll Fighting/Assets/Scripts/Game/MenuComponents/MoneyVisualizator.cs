using Sirenix.OdinInspector;
using UnityEngine;
using TMPro;
using Game.Economics;

namespace Game.MenuComponents
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class MoneyVisualizator : MonoBehaviour
    {
        [SerializeField] private PlayerPossesionsHandler _possesionsHandler;

        [Space(30)]
        [Header("Required Components:")]
        [Space(5)]
        [SerializeField] private TextMeshProUGUI _text;

        [Button]
        private void SetRequiredComponents()
        {
            _text = GetComponent<TextMeshProUGUI>();
        }

        private void OnEnable()
        {
            Visualize(_possesionsHandler.Money);
            _possesionsHandler.OnMoneyChanged += Visualize;
        }

        private void OnDisable()
        {
            _possesionsHandler.OnMoneyChanged -= Visualize;
        }

        private void Visualize(int money)
        {
            _text.text = money.ToString();
        }
    }
}