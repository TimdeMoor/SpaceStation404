using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace Gameplay
{
    public class PressureGaugeController : MonoBehaviour
    {
        private List<PressureGauge> _gauges;
        
        void Start()
        {
            _gauges = GetComponentsInChildren<PressureGauge>().ToList();
        }

        
        void Update()
        {
        
        }
    }
}
