using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;

namespace Gameplay.Puzzles.Valves
{
    public class PipeManager : MonoBehaviour
    {
        AudioSource audiosource;

        [SerializeField] private GameObject greenIndicator;
        [SerializeField] private GameObject redIndicator;

        private Material _greenIndicatorMaterial;
        private Material _redIndicatorMaterial;

        private List<Pipe> _pipes;
        public string _currentLayout;
        
        private bool _isSolved;
        bool dialogueStarted = false;
        
        void Start()
        {
            _pipes = GetComponentsInChildren<Pipe>().ToList();
            
            _greenIndicatorMaterial = greenIndicator.GetComponent<Renderer>().material;
            _greenIndicatorMaterial.color = new Color(0f,.25f,0f);
            
            _redIndicatorMaterial = redIndicator.GetComponent<Renderer>().material;
            _redIndicatorMaterial.color = new Color(1f,0f,0f);

            dialogueStarted = false;
        }

        private void Update()
        {
            //TODO: Convert to eventBased -> OnLayoutChanged
            GetCurrentLayout();

            if (CheckSolution())
            {
                _greenIndicatorMaterial.color = new Color(0f,1f,0f);
                _redIndicatorMaterial.color = new Color(.25f,0f,0f);
                _isSolved = true;

                audiosource = GetComponent<AudioSource>();

                if (_isSolved == true && dialogueStarted == false)
                {
                    dialogueStarted = true;
                    dialoguemanager dialoguemanager = FindObjectOfType<dialoguemanager>();
                    dialoguemanager.PlayDialogue(dialoguemanager.dialogue3);
                }
            }
            else
            {
                _greenIndicatorMaterial.color = new Color(0f,.25f,0f);
                _redIndicatorMaterial.color = new Color(1f,0f,0f);
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
    }
}
