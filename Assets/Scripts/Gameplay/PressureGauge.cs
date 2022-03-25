using UnityEngine;

namespace Gameplay
{
    public class PressureGauge : MonoBehaviour
    {
        [SerializeField] private Transform _GaugeIndicator;
        [SerializeField] private GameObject _PressureIndicator;

        private float minPos = -2.2f;
        private float maxPos = 2.2f; 
        
        [Range(0f, 99f)][SerializeField] float _value = 0f;
        [Range(0f, 99f)][SerializeField] float _targetValue = 0f;

        void Update()
        {
            SetPosition();
            SetPressureIndicator();
        }

        void SetPosition()
        {
            int valuePercentage = Mathf.RoundToInt(_value);
            float minmaxDifference = maxPos - minPos;
            Vector3 currentPos = _GaugeIndicator.transform.localPosition;
            
            var newZPos = (minmaxDifference/100f) * valuePercentage;
            _GaugeIndicator.transform.localPosition = 
                new Vector3(currentPos.x, currentPos.y, newZPos);
        }

        void SetPressureIndicator()
        {
            Material material = _PressureIndicator.GetComponent<Renderer>().material;

            material.color = Mathf.Round(_value) == _targetValue ? Color.green : Color.red;
        }

        public void SetValue(float newValue)
        {
            _value = newValue;
        }
    }
}
