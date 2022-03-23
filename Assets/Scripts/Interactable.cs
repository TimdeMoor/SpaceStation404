using UnityEngine;

public class Interactable : MonoBehaviour
{
    private PuzzleManager _puzzle;
    private bool _puzzleViewActive = false;

    private void Start()
    {
        _puzzle = GetComponentInParent<PuzzleManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            print("Tabbed");
            Interact();
        }
    }
    
    public void Interact()
    {
        _puzzle.TogglePuzzleView();
    }
}
