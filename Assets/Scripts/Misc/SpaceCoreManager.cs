using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class SpaceCoreManager : MonoBehaviour
{
    [SerializeField] private KeyCode manualTrigger = KeyCode.O;
    [SerializeField] private GameObject spaceCore;
    private PlayableDirector _timeLine;

    void Start()
    {
        _timeLine = GetComponentInChildren<PlayableDirector>();
        _timeLine.stopped += TimeLineStopped;
        spaceCore.SetActive(false);
    }

    void Update()
    {
        if (_timeLine.state == PlayState.Playing) return;

        if (RandomTrigger() || Input.GetKeyDown(manualTrigger))
        {
            TriggerSpaceCore();
        }
    }

    bool RandomTrigger()
    {
        if (!(Random.Range(0f, 100000f) <= 1f)) return false;
        print("SpaceCore Randomly Triggered");
        return true;
    }

    void TriggerSpaceCore()
    {
        spaceCore.SetActive(true);
        _timeLine.Play();
    }
    
    private void TimeLineStopped(PlayableDirector timeLine)
    {
        spaceCore.SetActive(false);
    }
}
