using Gameplay.General;
using UnityEngine;
using UnityEngine.Events;

public class Pipe : MonoBehaviour
{
    [SerializeField]private Transform _customPivot;
    public int _rotation = 0;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        _rotation %= 4; //if rotation > 3 then turn back to 0
    }
    
    private void OnMouseDown()
    {
        _rotation++;
        _audioSource.Play();
        
        Rotate90Deg();
    }
    
    public int GetRotation()
    {
        return _rotation;
    }

    private void Rotate90Deg()
    {
        transform.RotateAround(_customPivot.position, Vector3.forward, 90);
    }
}
