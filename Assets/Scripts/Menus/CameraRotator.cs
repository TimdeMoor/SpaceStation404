using System;
using System.Net.Http.Headers;
using UnityEditor;
using UnityEngine;

namespace Menus
{
    public class CameraRotator : MonoBehaviour
    {
        [SerializeField][Tooltip("In degrees per second")] 
        [Range(-45f,45f)]private float rotationSpeed = -5f;
        
        [SerializeField] public GameObject target;
        private Vector3 _targetPosition;
        
        void Start()
        {
            _targetPosition = target.transform.position;
        }
        
        void Update()
        {
            transform.RotateAround(_targetPosition, Vector3.up, rotationSpeed * Time.deltaTime);
        }

        //Shows the orbit
        private void OnDrawGizmos()
        {
            Handles.DrawWireDisc(_targetPosition, Vector3.up, Vector3.Distance(_targetPosition, transform.position));
        }
    }
}
