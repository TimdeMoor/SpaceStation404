using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnInputHandeler : MonoBehaviour
{
    // Start is called before the first frame update
    string output;
    
    bool geraakt;
    RaycastHit hit;
    void Start()
    {
        //denk aan verschillende lichtjes. je input verandert per lichtje, je output moet zijn output plus kleurlicht

        //we hebben nu een array met verschillende textmeshes. die waardes willen we zometeen gaan lezen
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit))
        {
            Transform objectHit = hit.transform;
            geraakt = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        var textmeshes = GetComponentsInChildren<TextMesh>();
       
        for (int i=0; i<16; i++) {
            if(Input.GetKeyDown(KeyCode.Mouse0)==true && geraakt==true)
            {
                //je zoekt de textmesh input, lees af wat die is. Zet die textmeshinput om naar string en gooi m bij de output.
                output = output + textmeshes[i].text.ToString();
                print(output);

                if (i == 15) { geraakt = false; }
                
            }

        }
        
    }
}
