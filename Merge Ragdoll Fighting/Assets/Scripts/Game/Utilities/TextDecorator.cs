﻿using Sirenix.OdinInspector;
using UnityEngine;
using TMPro;

namespace Game.Utilities
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class TextDecorator : MonoBehaviour
    {
        [SerializeField] private string _startingText;

        [Space(30)]
        [Header("Required Components:")]
        [Space(5)]
        [SerializeField] private TextMeshProUGUI _text;

        [Button]
        private void SetRequiredComponents()
        {
            _text = GetComponent<TextMeshProUGUI>();
        }

        public void Visualize(int value)
        {
            _text.text = _startingText + value.ToString();
        }
    }
}