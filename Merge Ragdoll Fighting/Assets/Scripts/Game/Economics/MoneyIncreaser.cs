using System;
using UnityEngine;

namespace Game.Economics
{
    public class MoneyIncreaser : MonoBehaviour
    {
        [SerializeField] private PlayerPossesionsHandler _possesionsHandler;
        [SerializeField] private int _minValue;
        [SerializeField] private int _maxValue;

        private void OnValidate()
        {
            if (_minValue < 0)
            {
                throw new InvalidOperationException("Min value can't be less than zero");
            }

            if (_maxValue < _minValue)
            {
                throw new InvalidOperationException("Max value can't be less than min value");
            }
        }

        public void IncreaseRandomly(out int increasedValue)
        {
            increasedValue = UnityEngine.Random.Range(_minValue, _maxValue);

            _possesionsHandler.AddMoney(increasedValue);
        }
    }
}