using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPadManager : MonoBehaviour
{
    [SerializeField]string KeypadTemplate;
    void Start()
    {
        var textmeshes = GetComponentsInChildren<TextMesh>();
        int i = 0;
        foreach(TextMesh textmesh in textmeshes)
        {
            textmesh.text = KeypadTemplate[i].ToString();
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
