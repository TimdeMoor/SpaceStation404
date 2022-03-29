using Cinemachine;
using UnityEngine;

namespace Gameplay.General
{
    public class PuzzleManager : MonoBehaviour
    {
        [SerializeField] private Movement playerMovement;
        [SerializeField] private CameraControl playerCamControl;
        [SerializeField] private GameObject playerModel;
        private CinemachineVirtualCamera _vCam;
        private bool _puzzleViewActive;
        void Start()
        {
            _vCam = GetComponentInChildren<CinemachineVirtualCamera>();
        }

        void Update()
        {
            //if the player presses tab while in the puzzleView
            if (_puzzleViewActive && Input.GetKeyDown(KeyCode.Tab))
            {
                TogglePuzzleView();
            }
        }
    
        public void TogglePuzzleView()
        {
            _puzzleViewActive = !_puzzleViewActive;
            _vCam.enabled = _puzzleViewActive;
            playerMovement.enabled = !_puzzleViewActive;
            playerCamControl.enabled = !_puzzleViewActive;

            Cursor.lockState = _puzzleViewActive ? CursorLockMode.Confined : CursorLockMode.Locked;
            
            Invoke(nameof(TogglePlayerModel), .5f);
        }

        public void TogglePlayerModel()
        {
            playerModel.SetActive(!_vCam.enabled);
        }
    }
}
