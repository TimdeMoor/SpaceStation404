using System;
using UnityEngine;

namespace Gameplay.Puzzles.PressureGauges
{
    public class Dial : MonoBehaviour
    {
        [SerializeField] private float maxRotation = 360f;
        [SerializeField] private float maxValue = 99f;

        private float _currentValue;
        
        
        public int GetValue()
        {
            float rotationPercentage = transform.localRotation.eulerAngles.y / maxRotation;
            _currentValue = rotationPercentage * maxValue;
            return (int)Math.Round(_currentValue);
        }
    }
}
