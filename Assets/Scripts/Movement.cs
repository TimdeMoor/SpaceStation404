using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 12f;
    private float _speedMult;

    private Transform _playerTransform;
    private CharacterController _controller;

    private float _newX;
    private float _newZ;

    private float _rollAxis;
    private float _upDownAxis;

    void Update()
    {
        SetupVariables();
        HandleInput();
        ApplyMovement();
        ApplyRotation();
    }


    private void SetupVariables()
    {
        _speedMult = speed * Time.deltaTime;
        
        _playerTransform = transform;
        _controller = GetComponent<CharacterController>();
    }
    
    private void HandleInput()
    {
        _newX = Input.GetAxis("Horizontal");
        _newZ = Input.GetAxis("Vertical");

        //TODO: Change to use unity's virtual button system
        if (Input.GetKey(KeyCode.Q)){ _rollAxis = 1f; }
        else if (Input.GetKey(KeyCode.E)){ _rollAxis = -1f; }
        else { _rollAxis = 0f; }
        
        if (Input.GetKey(KeyCode.Space)){ _upDownAxis = 1f; }
        else if (Input.GetKey(KeyCode.LeftShift)){ _upDownAxis = -1f; }
        else { _upDownAxis = 0f; }
    }

    private void ApplyMovement()
    {
        //Handles Left/Right and Front/Back movement
        Vector3 newLocation = _playerTransform.right * _newX + _playerTransform.forward * _newZ;
        _controller.Move(newLocation * _speedMult);
        
        //Handles up and down movement
        transform.Translate(0,_upDownAxis * _speedMult, 0);
    }

    private void ApplyRotation()
    {
        //Handles roll rotation
        transform.Rotate(0, 0, _rollAxis);
    }
}