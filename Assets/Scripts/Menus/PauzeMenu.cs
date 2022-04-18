using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Gameplay.General;
using UnityEngine;
using UnityEngine.Scripting;

public class PauzeMenu : MonoBehaviour
{
    private bool _isPaused;
    
    private Canvas _pauseUI;

    [SerializeField] private CameraControl _camera;
    [SerializeField] private GameObject _puzzlesParent;
    void Start()
    {
        _pauseUI = GetComponentInChildren<Canvas>();
        _pauseUI.enabled = false;
    }
    
    void Update()
    {
        if (!Input.GetKeyDown(KeyCode.P)) return;
        
        if (_isPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _isPaused = false;
        Time.timeScale = 1f;
        _pauseUI.enabled = false;
        _camera.enabled = true;
        
        foreach (Collider c in _puzzlesParent.GetComponentsInChildren<Collider>())
        {
            c.enabled = true;
        }
    }
    
    public void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        _isPaused = true;
        Time.timeScale = 0f;
        _pauseUI.enabled = true;
        _camera.enabled = false;

        foreach (Collider c in _puzzlesParent.GetComponentsInChildren<Collider>())
        {
            c.enabled = false;
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}
