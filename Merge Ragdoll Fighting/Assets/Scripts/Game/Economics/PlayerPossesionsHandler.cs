using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Game.MenuComponents;

namespace Game.Economics
{
    [CreateAssetMenu]
    public class PlayerPossesionsHandler : ScriptableObject
    {
        [SerializeField] private int _defaultMoney;
        [SerializeField] private List<int> _defaultAvailablePanels;

        private PlayerPossesions _possesions;
        private bool _initialized;
        private string _possesionsPath;

        public event Action<int> OnMoneyChanged;

        private readonly string _possesionsFile = "PlayerPossesions.json";

        public int Money => _possesions.Money;
        public IEnumerable<int> AvailablePanelIndificators => _possesions.AvailablePanels;

        public void Initialize()
        {
            if (_initialized == false)
            {
#if UNITY_ANDROID && !UNITY_EDITOR
            _playerPossesionsPath = Path.Combine(Application.persistentDataPath, _possesionsFile);
#else
                _possesionsPath = Path.Combine(Application.dataPath, _possesionsFile);
#endif
                _initialized = true;
            }

            if (File.Exists(_possesionsPath))
            {
                _possesions = JsonUtility.FromJson<PlayerPossesions>(File.ReadAllText(_possesionsPath));
            }
            else
            {
                _possesions = new PlayerPossesions(_defaultMoney, _defaultAvailablePanels);
            }
        }

        public void AddMoney(int money)
        {
            if (money < 0)
            {
                throw new ArgumentException("Money count must be positive");
            }

            _possesions.Money += money;
            OnMoneyChanged?.Invoke(_possesions.Money);
            SaveInfo();
        }

        public void TakeMoney(int money)
        {
            if (money < 0)
            {
                throw new ArgumentException("Money count must be positive");
            }

            _possesions.Money -= money;
            OnMoneyChanged?.Invoke(_possesions.Money);
        }

        public void AddPanel(int partPanelIndificator)
        {
            _possesions.AddPanel(partPanelIndificator);
            SaveInfo();
        }

        private void SaveInfo()
        {
            File.WriteAllText(_possesionsPath, JsonUtility.ToJson(_possesions));
        }
    }
}