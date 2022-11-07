using Sirenix.OdinInspector;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;
using Game.Economics;

namespace Game.MenuComponents
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class PanelBuyer : MonoBehaviour
    {
        [SerializeField] private PlayerPossesionsHandler _possesionsHandler;
        [SerializeField] private string _purchasingStartingText;
        [SerializeField] private string _onBoughtText;
        [SerializeField] private int _cost;
        [SerializeField] private PartPanel[] _buyingPanels;

        [Space(30)]
        [Header("Required Components:")]
        [Space(5)]
        [SerializeField] private TextMeshProUGUI _text;

        private bool _bought;

        [Button]
        private void SetRequiredComponents()
        {
            _text = GetComponent<TextMeshProUGUI>();
        }

        private void Start()
        {
            var availablePanels = _possesionsHandler.AvailablePanelIndificators;

            if (availablePanels.Contains(_buyingPanels.First().Indificator))
            {
                UnblockPanels(_buyingPanels);
                _text.text = _onBoughtText;
                _bought = true;
            }
            else
            {
                _text.text = _purchasingStartingText + _cost.ToString();
                BlockPanels(_buyingPanels);
            }
        }

        public void TryBuy()
        {
            if (_bought || _cost > _possesionsHandler.Money) return;

            Buy(_cost, _buyingPanels);
            _bought = true;
        }

        private void Buy(int cost, IEnumerable<PartPanel> panels)
        {
            _possesionsHandler.TakeMoney(cost);
            InitializePanels(panels);
        }

        private void InitializePanels(IEnumerable<PartPanel> panels)
        {
            foreach (var panel in panels)
            {
                _possesionsHandler.AddPanel(panel.Indificator);
                panel.Unblock();
            }

            _text.text = _onBoughtText;
        }

        private void BlockPanels(IEnumerable<PartPanel> panels)
        {
            foreach (var panel in panels)
            {
                panel.Block();
            }
        }

        private void UnblockPanels(IEnumerable<PartPanel> panels)
        {
            foreach (var panel in panels)
            {
                panel.Unblock();
            }
        }
    }
}