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
        [SerializeField] private GameObject redIndicator;

        private Material _greenIndicatorMaterial;
        private Material _redIndicatorMaterial;

        private List<Pipe> _pipes;
        private string _currentLayout;
        
        private bool _isSolved;
        
        void Start()
        {
            _pipes = GetComponentsInChildren<Pipe>().ToList();
            
            _greenIndicatorMaterial = greenIndicator.GetComponent<Renderer>().material;
            _greenIndicatorMaterial.color = new Color(0f,.25f,0f);
            
            _redIndicatorMaterial = redIndicator.GetComponent<Renderer>().material;
            _redIndicatorMaterial.color = new Color(1f,0f,0f);
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
            return Regex.IsMatch(_currentLayout, "23[13]112[0123]1011[02][02]0130[0123]2[02]0[13]333");
        }

        public bool GetSolvedState()
        {
            return _isSolved;
        }
    }
}
