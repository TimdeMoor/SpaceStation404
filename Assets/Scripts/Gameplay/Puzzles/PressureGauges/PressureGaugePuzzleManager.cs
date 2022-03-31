using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Puzzles.PressureGauges
{
    public class PressureGaugePuzzleManager : MonoBehaviour
    {
        [SerializeField] private List<PressureGauge> Gauges;
        [SerializeField] private List<Dial> Dials;
        private string _solutionCombination;

        void Start()
        {
            SetSolution();
        }
        
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

        private void SetSolution()
        {
            int i = 0;
            foreach (PressureGauge g in Gauges)
            {
                string newTarget = _solutionCombination[i].ToString() + _solutionCombination[i + 1].ToString();
                g.SetTargetValue(newTarget);
                i += 2;
            }
        }

        public void SetSolution(string newSolution)
        {
            _solutionCombination = newSolution;
        }
    }
}
