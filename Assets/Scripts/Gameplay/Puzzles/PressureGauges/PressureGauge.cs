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

        private AudioSource _correctSoundPlayer;
        private bool _soundPlayed;

        private bool _solved;

        private Light _light;
        

        void Start()
        {
            _correctSoundPlayer = GetComponent<AudioSource>();
           _pressureIndicatorMaterial = pressureIndicator.GetComponent<Renderer>().material;
           _pressureIndicatorMaterial.color = Color.black;
           _solved = false;
           _light = GetComponentInChildren<Light>();
        }
        void Update()
        {
            SetPosition();
            SetPressureIndicator();
        }

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
            if (Math.Abs(Mathf.Round(value) - targetValue) < float.Epsilon)
            {
                if (_soundPlayed) return;
                
                _pressureIndicatorMaterial.color = Color.green;
                _light.enabled = true;
                _solved = true;
                _correctSoundPlayer.Play();
                _soundPlayed = true;
            }
            else
            {
                _pressureIndicatorMaterial.color = Color.black;
                _soundPlayed = false;
                _solved = false;
                _light.enabled = false;
            }
        }

        public void SetValue(float newValue)
        {
            value = newValue;
        }

        public bool GetSolved()
        {
            return _solved;
        }
    }
}
