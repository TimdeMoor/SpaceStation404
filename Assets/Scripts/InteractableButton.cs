using UnityEngine;

public class InteractableButton : MonoBehaviour
{
    [SerializeField] private Door _door;
    private bool _doorOpen;

    public void ActivateButton()
    {
        print("DoorState:" + _doorOpen);
        ToggleState();
    }

    private void ToggleState()
    {
        Outline outline = GetComponent<Outline>();
        _doorOpen = !_doorOpen;

        outline.OutlineColor = _doorOpen ? Color.green : Color.red;
    }
}