using Cinemachine;
using TMPro;
using UnityEngine;

namespace Gameplay.General
{
    public class PuzzleViewToggle : MonoBehaviour
    {
        [SerializeField] private GameObject vCamParent;
        [SerializeField] private GameObject playerParent;
        [SerializeField] private TextMeshProUGUI goBackText;
        [SerializeField] private GameObject crosshair;
        
        private Movement _playerMovement;
        private CameraControl _playerCamControl;
        private GameObject _playerModel;

        private CinemachineVirtualCamera _vCam;
        private bool _puzzleViewActive;


        private void Start()
        {
            _vCam = vCamParent.GetComponent<CinemachineVirtualCamera>();
            _vCam.enabled = false;

            _playerMovement = playerParent.GetComponent<Movement>();
            _playerCamControl = playerParent.GetComponentInChildren<CameraControl>();

            _playerModel = playerParent.GetComponentInChildren<Animator>().gameObject;
        }
    
    
        public void Interact()
        {
            TogglePuzzleView();
        }
        
        void Update()
        {
            //if the player presses tab while in the puzzleView
            if (_puzzleViewActive && Input.GetKeyDown(KeyCode.Tab))
            {
                TogglePuzzleView();
            }
        }
    
        private void TogglePuzzleView()
        {
            _puzzleViewActive = !_puzzleViewActive;
            
            _vCam.enabled = _puzzleViewActive;
            _playerMovement.enabled = !_puzzleViewActive;
            _playerCamControl.enabled = !_puzzleViewActive;
            goBackText.enabled = _puzzleViewActive;
            _playerModel.SetActive(!_puzzleViewActive);
            crosshair.SetActive(!_puzzleViewActive);

            Cursor.lockState = _puzzleViewActive ? CursorLockMode.Confined : CursorLockMode.Locked;
        }
    }
}
