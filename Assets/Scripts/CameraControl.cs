using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity = 100f;
    [SerializeField] private Transform player;

    private float _mouseX;
    private float _mouseY;
    
    void Start()
    {
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
        _mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
    }

    private void ApplyRotation()
    {
        player.Rotate(Vector3.up * _mouseX);
        player.Rotate(Vector3.left * _mouseY);
    }
}
