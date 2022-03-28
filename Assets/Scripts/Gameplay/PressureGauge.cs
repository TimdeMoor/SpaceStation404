using System;
using UnityEngine;

namespace Gameplay
{
    public class PressureGauge : MonoBehaviour
    {
        [SerializeField] Transform gaugeIndicator;
        [SerializeField] GameObject pressureIndicator;

        private float minPos = -2.2f;
        private float maxPos = 2.2f; 
        
        [Range(0f, 99f)][SerializeField] private float _value;
        [Range(0f, 99f)][SerializeField] private float _targetValue;

        private Material _pressureIndicatorMaterial; 
        private int startingLightFlickerInterval = 30; //in frames -> 60 = 1sec
        private int _elapsedFrames = 0;

        void Start()
        {
           _pressureIndicatorMaterial = pressureIndicator.GetComponent<Renderer>().material;
           _pressureIndicatorMaterial.color = Color.black;
        }
        void Update()
        {
            SetPosition();
            SetPressureIndicator();
        }

        private void FixedUpdate()
        {
            _elapsedFrames++;
        }

        void SetPosition()
        {
            int valuePercentage = Mathf.RoundToInt(_value);
            float minmaxDifference = maxPos - minPos;
            Vector3 currentPos = gaugeIndicator.transform.localPosition;
            
            var newZPos = (minmaxDifference/100f) * valuePercentage;
            gaugeIndicator.transform.localPosition = 
                new Vector3(currentPos.x, currentPos.y, newZPos);
        }

        public void SetTargetValue(string newTarget)
        {
            _targetValue = Convert.ToInt16(newTarget);
        }

        void SetPressureIndicator()
        {
            if (Mathf.Round(_value) == _targetValue)
            {
                _pressureIndicatorMaterial.color = Color.white;
            }
            else
            {
                if (_elapsedFrames >= startingLightFlickerInterval)
                {
                    ToggleIndicatorLight();
                    _elapsedFrames = 0;
                }
            }
        }

        public void SetValue(float newValue)
        {
            _value = newValue;
        }

        private void ToggleIndicatorLight()
        {
            if (_pressureIndicatorMaterial.color == Color.white)
            {
                _pressureIndicatorMaterial.color = Color.black;
            }
            else
            {
                _pressureIndicatorMaterial.color = Color.white;
            }
        }
    }
}
