using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Gameplay.Puzzles.PressureGauges
{
    public class PressureGaugeController : MonoBehaviour
    {
        private List<PressureGauge> _gauges;
        
        void Start()
        {
            _gauges = GetComponentsInChildren<PressureGauge>().ToList();
        }
    }
}
