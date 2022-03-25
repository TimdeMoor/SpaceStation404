using System;
using UnityEngine;

namespace Gameplay
{
    public class Dial : MonoBehaviour
    {
        [SerializeField] private float minRotation = 0f;
        [SerializeField] private float maxRotation = 360f;

        [SerializeField] private float minValue = 0f;
        [SerializeField] private float maxValue = 100f;

        private float _currentValue;
        
        
        void Update()
        {
            _currentValue = (maxRotation - minRotation) / (minValue - maxValue);
        }

        public int GetValue()
        {
            return (int)Math.Round(_currentValue);
        }
    }
}
