using UnityEngine;

namespace Gameplay
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
        
            //if active -> color is green
            //else color is red
            outline.OutlineColor = _isActive ? Color.green : Color.red;
        }
    }
}