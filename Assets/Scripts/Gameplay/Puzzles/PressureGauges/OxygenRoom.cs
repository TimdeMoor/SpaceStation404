using Gameplay.Puzzles.Shared;
using Gameplay.Puzzles.Valves;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace Gameplay.Puzzles.PressureGauges
{
    public class OxygenRoom : MonoBehaviour
    {
        [Range(100000, 999999)][SerializeField] private int keyPadSolutionCode = 123456;
        [SerializeField] private bool isRandomCode;
        [SerializeField] private KeyPadManager keypad;
        [SerializeField] private PressureGaugePuzzleManager pressureGauges;
        [SerializeField] private DialController dials;
        [SerializeField] private PipeManager pipes;
        [SerializeField] private KeyPadManager hexaKeypad;
        [SerializeField] private GameObject door;
        void Start()
        {
            keypad = GetComponentInChildren<KeyPadManager>();
            pressureGauges = GetComponentInChildren<PressureGaugePuzzleManager>();
            dials = GetComponentInChildren<DialController>();
            
            if (isRandomCode)
            {
                keyPadSolutionCode = GetRandomCode();
                //check for 42069 easterEgg conflict
                while (keyPadSolutionCode.ToString().StartsWith("42069"))
                {
                    keyPadSolutionCode = GetRandomCode();
                }
            }
            print(keyPadSolutionCode);
            keypad.SetSolution(keyPadSolutionCode.ToString());
            pressureGauges.SetSolution(keyPadSolutionCode.ToString());

            DisablePuzzles();
        }

        void Update()
        {
            CheckPipesSolved();
            CheckGaugesSolved();
            CheckHexaSolved();
            CheckKeyPadSolved();
        }

        private int GetRandomCode()
        {
            return Random.Range(100000, 999999);
        }

        private void CheckPipesSolved()
        {
            if (pipes.GetSolvedState())
            {
                ActivateDials();
            }
            else
            {
                DeActivateDials();
            }
        }

        private void CheckGaugesSolved()
        {
            if (!pressureGauges.PressureGaugesSolved()) return;
            hexaKeypad.EnableKeypad();
        }

        private void CheckHexaSolved()
        {
            if (!hexaKeypad.Solved()) return;
            ActivateKeyPad();
            DeActivateHexKeypad();
        }

        private void CheckKeyPadSolved()
        {
            if (keypad.Solved())
            {
                Destroy(door);
            }
        }

        private void ActivateDials()
        {
            dials.Activate();
        }

        private void DeActivateDials()
        {
            dials.Deactivate();
        }

        private void DeActivateHexKeypad()
        {
            hexaKeypad.DisableKeypad();
        }

        private void ActivateHexKeypad()
        {
            hexaKeypad.EnableKeypad();
        }

        private void ActivateGauges()
        {
            dials.Activate();
        }

        private void DeActivateGauges()
        {
            dials.Deactivate();
        }

        private void DeActivateKeyPad()
        {
            keypad.DisableKeypad();
        }

        private void ActivateKeyPad()
        {
            keypad.EnableKeypad();
        }

        private void DisablePuzzles()
        {
            DeActivateKeyPad();
            DeActivateHexKeypad();
            //DeActivateGauges();
        }
    }
}
