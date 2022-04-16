using UnityEngine;

namespace Gameplay.General
{
    public class CameraControl : MonoBehaviour
    {
        [Range(0.1f, 2f)][SerializeField] private float mouseSensitivity = .6f;
        [SerializeField] private Transform player;

        private float _mouseX;
        private float _mouseY;
        private float _invertMouseMultiplier = 1;
    
        void Start()
        {
            if (PlayerPrefs.GetInt("invertMouse") != 0)
            {
                _invertMouseMultiplier = -1;
            }
            
            Cursor.lockState = CursorLockMode.Locked;
        }
    
        void Update()
        {
            HandleInput();
            ApplyRotation();
        }


        private void HandleInput()
        {
            _mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            _mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * _invertMouseMultiplier * Time.deltaTime;
        }

        private void ApplyRotation()
        {
            player.Rotate(Vector3.up * _mouseX / Time.deltaTime);
            player.Rotate(Vector3.left * _mouseY / Time.deltaTime);
        }
    }
}
