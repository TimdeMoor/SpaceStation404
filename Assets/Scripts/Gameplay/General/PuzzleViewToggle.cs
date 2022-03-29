using Cinemachine;
using UnityEngine;

namespace Gameplay.General
{
    public class PuzzleViewToggle : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera vCam;
        private PuzzleManager _puzzle;
        

        private void Start()
        {
            _puzzle = GetComponentInParent<PuzzleManager>();
            vCam.enabled = false;
        }
    
    
        public void Interact()
        {
            _puzzle.TogglePuzzleView();
        }
    }
}
