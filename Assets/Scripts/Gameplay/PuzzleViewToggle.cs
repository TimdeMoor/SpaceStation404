using UnityEngine;

namespace Gameplay
{
    public class PuzzleViewToggle : MonoBehaviour
    {
        private PuzzleManager _puzzle;

        private void Start()
        {
            _puzzle = GetComponentInParent<PuzzleManager>();
        }
    
    
        public void Interact()
        {
            _puzzle.TogglePuzzleView();
        }
    }
}
