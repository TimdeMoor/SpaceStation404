using UnityEngine;

namespace Menus
{
    public class CameraRotator : MonoBehaviour
    {
        [SerializeField][Tooltip("In degrees per second")] 
        [Range(-45f,45f)]private float _rotationSpeed = -5f;
        
        [SerializeField] public GameObject target;

        
        void Update()
        {
            transform.RotateAround(target.transform.position, Vector3.up, _rotationSpeed * Time.deltaTime);
        }
    }
}
