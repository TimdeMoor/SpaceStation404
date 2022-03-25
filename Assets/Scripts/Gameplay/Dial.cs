using System;
using UnityEngine;

namespace Gameplay
{
    public class Dial : MonoBehaviour
    {
        [SerializeField] private float maxRotation = 360f;
        [SerializeField] private float maxValue = 99f;

        private float _currentValue;

        float rotationSpeed = 0.2f;
        private Renderer _renderer;

        void Start()
        {
            _renderer = GetComponent<Renderer>();
        }
        
        public int GetValue()
        {
            float rotationPercentage = transform.localRotation.eulerAngles.y / maxRotation;
            _currentValue = rotationPercentage * maxValue;
            return (int)Math.Round(_currentValue);
        }
    }
}
