using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDragRotate : MonoBehaviour {
    float rotationSpeed = 0.05f;
 
    void OnMouseDrag()
    {
        float XaxisRotation = Input.GetAxis("Mouse X")*rotationSpeed;
        //float YaxisRotation = Input.GetAxis("Mouse Y")*rotationSpeed;
        // select the axis by which you want to rotate the GameObject
        transform.RotateAround (Vector3.down, XaxisRotation);
        //transform.RotateAround (Vector3.right, YaxisRotation);
    }
}
