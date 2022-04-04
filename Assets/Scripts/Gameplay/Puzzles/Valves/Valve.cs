using System;
using UnityEngine;

namespace Gameplay.Puzzles.Valves
{
    public class Valve : MonoBehaviour
    {
        private bool _isOpen;
        

        private void OnMouseDown()
        {
            _isOpen = !_isOpen;
            print("Valve is now " + (_isOpen ? "open" : "closed"));
            SetPosition();
        }

        private void SetPosition()
        {
            if (_isOpen)
            {
                transform.localRotation = Quaternion.Euler(180, 0, 0);
            } 
            else
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
        }
    }
}
