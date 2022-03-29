using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KeyPadManager : MonoBehaviour
{
    [SerializeField]string KeypadTemplate;
    private string ScreenText;
    [SerializeField] private TextMeshPro KeyPadScreenText;
    private int maxLength = 6;
    private int currentLength = 0;
    
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

    public void AddToScreen(string toAdd)
    {
        if (currentLength != maxLength)
        {
            ScreenText += toAdd;
            currentLength++;
        }
        else
        {
            currentLength = 0;
        }
    }

    private void Update()
    {
        KeyPadScreenText.text = ScreenText;
    }
}
