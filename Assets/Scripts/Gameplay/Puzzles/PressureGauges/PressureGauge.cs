using System;
using UnityEngine;

namespace Gameplay.Puzzles.PressureGauges
{
    public class PressureGauge : MonoBehaviour
    {
        [SerializeField] Transform gaugeIndicator;
        [SerializeField] GameObject pressureIndicator;

        private float minPos = -2.2f;
        private float maxPos = 2.2f; 
        
        [Range(0f, 99f)][SerializeField] private float value;
        [Range(0f, 99f)][SerializeField] private float targetValue;

        private Material _pressureIndicatorMaterial; 
        //private int startingLightFlickerInterval = 30; //in frames -> 60 = 1sec
        //private int _elapsedFrames = 0;

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

        //private void FixedUpdate()
        //{
        //    _elapsedFrames++;
        //}

        private void SetPosition()
        {
            int valuePercentage = Mathf.RoundToInt(value);
            float minmaxDifference = maxPos - minPos;
            Vector3 currentPos = gaugeIndicator.transform.localPosition;
            
            var newZPos = (minmaxDifference/100f) * valuePercentage;
            gaugeIndicator.transform.localPosition = new Vector3(currentPos.x, currentPos.y, newZPos);
        }

        public void SetTargetValue(string newTarget)
        {
            targetValue = Convert.ToInt16(newTarget);
        }

        private void SetPressureIndicator()
        {
            //compare value and targetValue
            _pressureIndicatorMaterial.color = Math.Abs(Mathf.Round(value) - targetValue) < float.Epsilon ? Color.green : Color.red;
        }

        public void SetValue(float newValue)
        {
            value = newValue;
        }

        //private void ToggleIndicatorLight()
        //{
        //    _pressureIndicatorMaterial.color = _pressureIndicatorMaterial.color == Color.red ? Color.green : Color.red;
        //}
    }
}
