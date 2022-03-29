using UnityEngine;

namespace Gameplay.General
{
    public class InteractableButton : MonoBehaviour
    {
        private bool _isActive;

        public void ActivateButton()
        {
            ToggleState();
        }

        private void ToggleState()
        {
            Outline outline = GetComponent<Outline>();
            _isActive = !_isActive;
            
            outline.OutlineColor = _isActive ? Color.green : Color.red;
        }
    }
}