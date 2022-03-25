using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public class PressureGaugePuzzleManager : MonoBehaviour
    {
        [SerializeField] private List<PressureGauge> Gauges;
        [SerializeField] private List<Dial> Dials;
        void Update()
        {
            SetGauges();
        }

        private void SetGauges()
        {
            int i = 0;
            foreach (Dial dial in Dials)
            {
                Gauges[i].SetValue(dial.GetValue());
                i++;
            }
        }
    }
}
