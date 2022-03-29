using UnityEngine;

namespace Gameplay.General
{
    public class MouseDragRotate : MonoBehaviour {
        float rotationSpeed = -0.5f;
 
        void OnMouseDrag()
        {
            float xAxisRotation = Input.GetAxis("Mouse X") * rotationSpeed;
            transform.Rotate(Vector3.down, xAxisRotation);
        }
    }
}
