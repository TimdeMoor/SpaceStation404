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
        
        SetRotation(_rotation);
    }
    
    public int GetRotation()
    {
        return _rotation;
    }

    private void SetRotation(int rotationIndex)
    {
        //transform.localRotation = Quaternion.Euler(new Vector3(0,0,0));
        transform.RotateAround(_customPivot.position, Vector3.forward, rotationIndex * 90);
    }
}
