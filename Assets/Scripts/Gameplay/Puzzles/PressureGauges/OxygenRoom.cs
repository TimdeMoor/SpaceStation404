using Gameplay.Puzzles.Valves;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Gameplay.Puzzles.PressureGauges
{
    public class OxygenRoom : MonoBehaviour
    {
        [Range(100000, 999999)][SerializeField] private int keyPadSolutionCode = 123456;
        [SerializeField] private bool isRandomCode;
        private KeyPadManager _keypad;
        private PressureGaugePuzzleManager _pressureGauges;
        private DialController _dials;
        private PipeManager _pipes;

        void Start()
        {
            _keypad = GetComponentInChildren<KeyPadManager>();
            _pressureGauges = GetComponentInChildren<PressureGaugePuzzleManager>();
            _pipes = GetComponentInChildren<PipeManager>();
            _dials = GetComponentInChildren<DialController>();

            if (isRandomCode)
            {
                //check for 42069 easterEgg conflict
                while (keyPadSolutionCode.ToString().StartsWith("42069"))
                {
                    keyPadSolutionCode = GetRandomCode();
                }
            }
        
            _keypad.SetSolution(keyPadSolutionCode.ToString());
            _pressureGauges.SetSolution(keyPadSolutionCode.ToString());
        }

        void Update()
        {
            CheckPipesSolved();
        }

        int GetRandomCode()
        {
            return Random.Range(100000, 999999);
        }

        private void CheckPipesSolved()
        {
            if (_pipes.GetSolvedState())
            {
                ActivateDials();
            }
            else
            {
                DeActivateDials();
            }
        }

        private void ActivateDials()
        {
            _dials.Activate();
        }

        private void DeActivateDials()
        {
            _dials.Deactivate();
        }
    }
}
