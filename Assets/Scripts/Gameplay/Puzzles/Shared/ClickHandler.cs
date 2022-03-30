using Gameplay.Puzzles.PressureGauges;
using TMPro;
using UnityEngine;

namespace Gameplay.Puzzles.Shared
{
    public class ClickHandler : MonoBehaviour
    {
        private TextMeshPro _textMesh;
        private KeyPadManager _keypad;
        void Start()
        {
            _textMesh = GetComponentInChildren<TextMeshPro>();
            _keypad = GetComponentInParent<KeyPadManager>();
        }

        private void OnMouseDown()
        {
            _keypad.AddToScreen(_textMesh.text);
        }
    }
}
