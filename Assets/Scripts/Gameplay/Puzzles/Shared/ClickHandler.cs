using Gameplay.Puzzles.PressureGauges;
using UnityEngine;

namespace Gameplay.Puzzles.Shared
{
    public class ClickHandler : MonoBehaviour
    {
        private TextMesh _textMesh;
        private KeyPadManager _keypad;
        void Start()
        {
            _textMesh = GetComponentInChildren<TextMesh>();
            _keypad = GetComponentInParent<KeyPadManager>();
        }

        private void OnMouseDown()
        {
            _keypad.AddToScreen(_textMesh.text);
        }
    }
}
