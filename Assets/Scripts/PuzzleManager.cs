using Cinemachine;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    private CinemachineVirtualCamera _vCam;
    private 
    void Start()
    {
        _vCam = GetComponentInChildren<CinemachineVirtualCamera>();
    }

    public void TogglePuzzleView()
    {
        _vCam.enabled = !_vCam.enabled;
    }
}
