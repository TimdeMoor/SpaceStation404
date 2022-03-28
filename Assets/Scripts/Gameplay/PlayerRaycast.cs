using UnityEngine;

namespace Gameplay
{
    public class PlayerRaycast : MonoBehaviour
    {
        [SerializeField] private int rayLength = 3;
        [SerializeField] private KeyCode interactionKey = KeyCode.Mouse0;
        private InteractableButton _raycastButton;
    

        private void Update()
        {
            GameObject rayCastHitObject = GetRayCastHitObject();
        
            //check for interactionKey
            if (Input.GetKeyDown(interactionKey))
            {
                //check if there is an object being looked at
                if (rayCastHitObject != null)
                {
                    //print("Clicked on: " + rayCastHitObject.name);
                
                    //if the object being looked at is a button
                    if (rayCastHitObject.GetComponent<InteractableButton>() != null)
                    {
                        _raycastButton = rayCastHitObject.GetComponent<InteractableButton>();
                        _raycastButton.ActivateButton();
                    }
                    //if the object being looked at is a generic interactable
                    else if (rayCastHitObject.GetComponent<PuzzleViewToggle>() != null)
                    {
                        print("Interactable Triggered");
                        rayCastHitObject.GetComponent<PuzzleViewToggle>().Interact();
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
}