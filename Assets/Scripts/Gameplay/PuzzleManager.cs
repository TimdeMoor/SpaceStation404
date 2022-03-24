using Cinemachine;
using UnityEngine;

namespace Gameplay
{
    public class PuzzleManager : MonoBehaviour
    {
        [SerializeField] Movement playerMovement;
        [SerializeField] CameraControl playerCamControl;
        [SerializeField] GameObject playerModel;
        private CinemachineVirtualCamera _vCam;
        private bool _puzzleViewActive = false;
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
            _vCam.enabled = !_vCam.enabled;
            _puzzleViewActive = _vCam.enabled;
            playerMovement.enabled = !_vCam.enabled;
            playerCamControl.enabled = !_vCam.enabled;
            Invoke("TogglePlayerModel", .5f);
        }

        public void TogglePlayerModel()
        {
            playerModel.SetActive(!_vCam.enabled);
        }
    }
}
