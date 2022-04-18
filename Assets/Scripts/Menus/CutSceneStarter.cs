using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CutSceneStarter : MonoBehaviour
{
    private PlayableDirector _timeLine;
    
    void Start()
    {
        _timeLine = GetComponentInParent<PlayableDirector>();
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.name != "Player") return;
        
        _timeLine.Play();
        Invoke(nameof(ToCredits), 10f);
    }

    void ToCredits()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
