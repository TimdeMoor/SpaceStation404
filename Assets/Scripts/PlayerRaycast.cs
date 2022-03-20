using UnityEngine;

public class PlayerInteractionRaycaster : MonoBehaviour
{
    [SerializeField] private int rayLength = 3;
    [SerializeField] private KeyCode interactionKey = KeyCode.Mouse0;
    private InteractableButton _raycastButton;
    

    private void Update()
    {
        GameObject rayCastObject = GetRayCastObject();
        if (rayCastObject != null)
        {
            _raycastButton = rayCastObject.GetComponent<InteractableButton>();
        }
        
        if (Input.GetKeyDown(interactionKey) && _raycastButton != null)
        {
            _raycastButton.ActivateButton();
        }

        if(rayCastObject){print(rayCastObject.name);}
    }

    //returns the object the player is looking at
    private GameObject GetRayCastObject()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        
        if (Physics.Raycast(transform.position, forward, out RaycastHit hit, rayLength))
        {
            return hit.collider.gameObject;
        }
        return null;
    }
    
    private void OnDrawGizmos()
    {
        Transform player = transform;
        Gizmos.color = Color.red;
        Vector3 forward = player.TransformDirection(Vector3.forward);
        Gizmos.DrawRay(player.position, forward * rayLength);
    }
    
    
}