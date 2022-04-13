using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Puzzles.PressureGauges
{
    public class PressureGaugePuzzleManager : MonoBehaviour
    {
        AudioSource audiosource;

        [SerializeField] private List<PressureGauge> Gauges;
        [SerializeField] private List<Dial> Dials;
        private string _solutionCombination = string.Empty;
        bool dialogueplayed = false;
        void Start()
        {
            //SetSolution();
        }
        
        void Update()
        {
            SetGauges();
            if (PressureGaugesSolved() && !dialogueplayed)
            {
                //play next Dialogue
                DialogueManager dialoguemanager = FindObjectOfType<DialogueManager>();
                dialoguemanager.PlayDialogue(dialoguemanager.dialogue4);
                Debug.Log("tyfuszooi");
                dialogueplayed = true;

            }

            if(Input.GetKeyDown(KeyCode.O))
            {
                DialogueManager dialoguemanager = FindObjectOfType<DialogueManager>();
                dialoguemanager.PlayDialogue(dialoguemanager.dialogue4);
            }
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
            SetSolution();
        }

        private bool PressureGaugesSolved()
        {
            bool allSolved = true;
            foreach (PressureGauge g in Gauges)
            {
                if (!g.getSolved())
                {
                    allSolved = false;
                }
            }

            return allSolved;
        }
    }
}
