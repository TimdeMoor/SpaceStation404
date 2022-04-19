using System.Collections.Generic;
using Gameplay.General;
using UnityEngine;

namespace Gameplay.Puzzles.PressureGauges
{
    public class PressureGaugePuzzleManager : MonoBehaviour
    {
        [SerializeField] private List<PressureGauge> gauges;
        [SerializeField] private List<Dial> dials;
        private string _solutionCombination = string.Empty;
        private bool _dialoguePlayed;

        void Update()
        {
            SetGauges();
            if (PressureGaugesSolved() && !_dialoguePlayed)
            {
                DialogueManager dialogueManager = FindObjectOfType<DialogueManager>();
                dialogueManager.PlayDialogue(dialogueManager.dialogue4);
                _dialoguePlayed = true;
            }
        }

        private void SetGauges()
        {
            int i = 0;
            foreach (Dial dial in dials)
            {
                gauges[i].SetValue(dial.GetValue());
                i++;
            }
        }

        private void SetSolution()
        {
            int i = 0;
            foreach (PressureGauge g in gauges)
            {
                string newTarget = _solutionCombination[i].ToString() + _solutionCombination[i + 1].ToString();
                g.SetTargetValue(newTarget);
                i += 2;
            }
        }

        public void SetSolution(string newSolution)
        {
            _solutionCombination = newSolution;
            SetSolution();
        }

        public bool PressureGaugesSolved()
        {
            bool allSolved = true;
            foreach (PressureGauge g in gauges)
            {
                if (!g.GetSolved())
                {
                    allSolved = false;
                }
            }

            return allSolved;
        }
    }
}
