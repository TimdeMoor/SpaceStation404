using UnityEngine;

namespace Gameplay.General
{
    public class MouseDragRotate : MonoBehaviour {
        [SerializeField][Range(0.1f, 2f)] private float rotationSpeed = 0.5f;
        [SerializeField] private bool invertRotation;

        void Start()
        {
            if (invertRotation) rotationSpeed *= -1f;
        }
        
        void OnMouseDrag()
        {
            float xAxisRotation = Input.GetAxis("Mouse X") * rotationSpeed;
            transform.Rotate(Vector3.down, xAxisRotation);
        }
    }
}
