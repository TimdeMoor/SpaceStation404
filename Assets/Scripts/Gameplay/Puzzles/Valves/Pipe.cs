using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    [SerializeField]private Transform _customPivot;
    public int _rotation = 0;
    
    
    private void OnMouseDown()
    {
        _rotation = (_rotation + 1) % 4; //if rotation > 4 then turn back to 1
        Rotate90Deg();
    }

    private void Rotate90Deg()
    {
        transform.RotateAround(_customPivot.position, Vector3.forward, 90);
    }

    public int GetRotation()
    {
        return _rotation;
    }
}
