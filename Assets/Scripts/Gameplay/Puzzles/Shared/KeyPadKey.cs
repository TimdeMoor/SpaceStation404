using Gameplay.Puzzles.PressureGauges;
using TMPro;
using UnityEngine;

namespace Gameplay.Puzzles.Shared
{
    public class KeyPadKey : MonoBehaviour
    {
        private TextMeshPro _textMesh;
        private KeyPadManager _keypad;
        private AudioSource _clickAudio;
        
        void Start()
        {
            _textMesh = GetComponentInChildren<TextMeshPro>();
            _keypad = GetComponentInParent<KeyPadManager>();
            _clickAudio = GetComponent<AudioSource>();
        }

        private void OnMouseDown()
        {
            _keypad.AddToScreen(_textMesh.text);
            _clickAudio.pitch = Random.Range(1f, 1.5f);
            _clickAudio.PlayDelayed(.01f);
        }
    }
}
