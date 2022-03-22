using UnityEngine;

public class InteractableButton : MonoBehaviour
{
    private bool _isActive;

    public void ActivateButton()
    {
        print("Active:" + _isActive);
        ToggleState();
    }

    private void ToggleState()
    {
        Outline outline = GetComponent<Outline>();
        _isActive = !_isActive;
        
        outline.OutlineColor = _isActive ? Color.green : Color.red;
    }
}