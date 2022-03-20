using UnityEngine;

public class Door : MonoBehaviour
{
    private bool _isOpen;
    private Collider _collider;
    private Renderer _renderer;
    
    void Start()
    {
        _collider = GetComponent<Collider>();
        _renderer = GetComponent<Renderer>();
    }
    
    public void ToggleDoor()
    {
        _collider.enabled = !_collider.enabled;
        _renderer.enabled = !_renderer.enabled;
    }
}