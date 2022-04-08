using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Gameplay.Puzzles.Valves
{
    public class PipeManager : MonoBehaviour
    {
        private List<Pipe> _pipes;
        public string _currentLayout;

        public string solutionLayout;
        
        void Start()
        {
            _pipes = GetComponentsInChildren<Pipe>().ToList();
        }

        private void Update()
        {
            GetCurrentLayout();
        }

        void GetCurrentLayout()
        {
            _currentLayout = String.Empty;
            
            foreach (Pipe p in _pipes)
            {
                _currentLayout += p.GetRotation().ToString();
            }
        }

        public void SetSolution(string newSolution)
        {
            solutionLayout = newSolution;
        }
    }
}
