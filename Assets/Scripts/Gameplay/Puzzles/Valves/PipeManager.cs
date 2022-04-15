using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;

namespace Gameplay.Puzzles.Valves
{
    public class PipeManager : MonoBehaviour
    {
        [SerializeField] private GameObject greenIndicator;
        [SerializeField] private Light greenLight;
        
        [SerializeField] private GameObject redIndicator;
        [SerializeField] private Light redLight;
        
        private Material _greenIndicatorMaterial;
        private Material _redIndicatorMaterial;

        private List<Pipe> _pipes;
        private string _currentLayout;
        
        private bool _isSolved;
        bool _dialogueStarted = false;
        
        void Start()
        {
            _pipes = GetComponentsInChildren<Pipe>().ToList();
            
            _greenIndicatorMaterial = greenIndicator.GetComponent<Renderer>().material;
            _greenIndicatorMaterial.color = new Color(0f,.25f,0f);
            greenLight.color = Color.green;
            greenLight.enabled = false;
            
            _redIndicatorMaterial = redIndicator.GetComponent<Renderer>().material;
            _redIndicatorMaterial.color = new Color(1f,0f,0f);
            redLight.color = Color.red;
            redLight.enabled = true;

            _dialogueStarted = false;
        }

        private void Update()
        {
            //TODO: Convert to eventBased -> OnLayoutChanged
            GetCurrentLayout();

            if (CheckSolution())
            {
                _greenIndicatorMaterial.color = new Color(0f,1f,0f);
                _redIndicatorMaterial.color = new Color(.25f, 0f, 0f);
                greenLight.enabled = true;
                redLight.enabled = false;
                
                _isSolved = true;

                if (_isSolved && !_dialogueStarted)
                {
                    _dialogueStarted = true;
                    DialogueManager dialogueManager = FindObjectOfType<DialogueManager>();
                    dialogueManager.PlayDialogue(dialogueManager.dialogue3);
                    DeactivatePipes();
                }
            }
            else
            {
                _greenIndicatorMaterial.color = new Color(0f,.25f,0f);
                _redIndicatorMaterial.color = new Color(1f,0f,0f);
                greenLight.enabled = false;
                redLight.enabled = true;
                _isSolved = false;
            }
        }

        void GetCurrentLayout()
        {
            _currentLayout = String.Empty;
            
            foreach (Pipe p in _pipes)
            {
                _currentLayout += p.GetRotation().ToString();
            }
        }

        private bool CheckSolution()
        {
            return Regex.IsMatch(_currentLayout, "21[13]332[0123]3033[02][02]0310[0123]2[02]0[13]111");
        }

        public bool GetSolvedState()
        {
            return _isSolved;
        }

        private void DeactivatePipes()
        {
            foreach (Pipe p in _pipes)
            {
                p.gameObject.GetComponent<Collider>().enabled = false;
            }
        }
    }
}
