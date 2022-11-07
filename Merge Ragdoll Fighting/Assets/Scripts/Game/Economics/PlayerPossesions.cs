using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.Economics
{
    [Serializable]
    public class PlayerPossesions
    {
        [SerializeField] private int _money;
        [SerializeField] private List<int> _availablePanels = new List<int>();

        public PlayerPossesions(int money, IEnumerable<int> availablePanels)
        {
            Money = money;
            _availablePanels = availablePanels.ToList();
        }

        public int Money
        {
            get => _money;

            set
            {
                if (value < 0) throw new ArgumentException("Money count must be positive");

                _money = value;
            }
        }

        public IEnumerable<int> AvailablePanels => _availablePanels;

        public void AddPanel(int panelIndificator)
        {
            if (_availablePanels.Contains(panelIndificator) == false)
            {
                _availablePanels.Add(panelIndificator);
            }
        }
    }
}
