using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
    [SerializeField] private int rayLength = 3;
    [SerializeField] private KeyCode interactionKey = KeyCode.Mouse0;
    private InteractableButton _raycastButton;
    

    private void Update()
    {
        GameObject rayCastHitObject = GetRayCastHitObject();
        
        
        if (Input.GetKeyDown(interactionKey))
        {
            if (rayCastHitObject != null)
            {
                print("Clicked on: " + rayCastHitObject.name);
                
                if (rayCastHitObject.GetComponent<InteractableButton>() != null)
                {
                    _raycastButton = rayCastHitObject.GetComponent<InteractableButton>();
                    _raycastButton.ActivateButton();
                }else if (rayCastHitObject.GetComponent<Interactable>() != null)
                {
                    print("Interactable Triggered");
                    rayCastHitObject.GetComponent<Interactable>().Interact();
                }
            }
        }
    }

    //returns the object the player is looking at
    private GameObject GetRayCastHitObject()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        
        if (Physics.Raycast(transform.position, forward, out RaycastHit hit, rayLength))
        {
            return hit.collider.gameObject;
        }
        return null;
    }

    //add an outline to an object
    private void SetObjectOutlineColor(GameObject obj, Color color)
    {
        //check if object already has an outline
        if (obj.GetComponent<Outline>() != null)
        {
            Outline outline = obj.GetComponent<Outline>();
            outline.OutlineColor = color;
            outline.OutlineWidth = 10;
            outline.OutlineMode = Outline.Mode.OutlineVisible;
        }
    }
    
    private void OnDrawGizmos()
    {
        Transform player = transform;
        Gizmos.color = Color.red;
        Vector3 forward = player.TransformDirection(Vector3.forward);
        Gizmos.DrawRay(player.position, forward * rayLength);
    }
}