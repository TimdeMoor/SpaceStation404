using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutSceneStarter : MonoBehaviour
{
    private PlayableDirector _timeLine;
    
    void Start()
    {
        _timeLine = GetComponentInParent<PlayableDirector>();
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.name == "Player")
        {
            _timeLine.Play();
        }
    }
}
