using System.Collections.Generic;
using System.Linq;
using Gameplay.General;
using Gameplay.Puzzles.Shared;
using TMPro;
using UnityEngine;

namespace Gameplay.Puzzles.PressureGauges
{
    public class KeyPadManager : MonoBehaviour
    {
        [SerializeField] private string keypadTemplate;
        [SerializeField] private TextMeshPro keyPadScreenText; 
        [SerializeField] private GameObject greenIndicator;
        [SerializeField] private GameObject redIndicator;
        [SerializeField] private dialoguemanager dialogue;

        [SerializeField] private string _solution;
        private string _screenText;
        private int _maxLength = 6;
        private int _currentLength;
        bool _solved;

        private Material _greenIndicatorMaterial;
        private Material _redIndicatorMaterial;

        [SerializeField] private AudioClip codeCorrectSound;
        [SerializeField] private AudioClip codeWrongSound;
        private AudioSource _keypadAudio;
        
        void Start()
        {
            _greenIndicatorMaterial = greenIndicator.GetComponent<Renderer>().material;
            _greenIndicatorMaterial.color = new Color(0f,.25f,0f);
            
            _redIndicatorMaterial = redIndicator.GetComponent<Renderer>().material;
            _redIndicatorMaterial.color = new Color(.25f,0f,0f);
            
            List<TextMeshPro> textMeshes = GetComponentsInChildren<TextMeshPro>().ToList();
            textMeshes.RemoveAt(textMeshes.Count - 1); //Remove the keypadScreenTextMesh

            _keypadAudio = GetComponent<AudioSource>();
            
            int i = 0;
            foreach(TextMeshPro textMesh in textMeshes)
            {
                textMesh.text = keypadTemplate[i].ToString();
                i++;
            }
        }

        public void SetSolution(string newSolution)
        {
            _solution = newSolution;
        }

        public void AddToScreen(string toAdd)
        {
            //check if a character can be added and if the puzzle is solved
            if (_currentLength != _maxLength && !_solved)
            {
                _screenText += toAdd;
                _currentLength++;
                if (_currentLength == _maxLength)
                {
                    ResetKeyPad();
                }
            }
        }

        private void CheckSolution()
        {
            _solved = keyPadScreenText.text == _solution;
        }

        private void Update()
        {
            keyPadScreenText.text = _screenText;
            CheckSolution();
            
            if (_solved)
            {
                PlayCorrectSound();
                DisableButtons();
                keyPadScreenText.text = "Correct";
                
                
                //Switch lights
                _greenIndicatorMaterial.color = new Color(0f,1f,0f);
                _redIndicatorMaterial.color = new Color(.25f,0f,0f);
            }

            //Nice!
            if (_screenText == "42069")
            {
                _screenText = "Nice!";
                ResetKeyPad();
            }
        }

        private void DisableButtons()
        {
            //Disable the buttonColliders from the keypadButtons
            foreach (KeyPadKey key in GetComponentsInChildren<KeyPadKey>())
            {
                key.gameObject.GetComponent<Collider>().enabled = false;
            }
        }

        private void EnableButtons()
        {
            foreach (KeyPadKey key in GetComponentsInChildren<KeyPadKey>())
            {
                key.gameObject.GetComponent<Collider>().enabled = true;
            }
        }

        private void FlashRedLight()
        {
            ToggleRedLightOn();
            Invoke(nameof(ToggleRedLightOff), 1f);
        }

        private void ToggleRedLightOn()
        {
            _redIndicatorMaterial.color = new Color(1f,0f,0f);
        }
        private void ToggleRedLightOff()
        {
            _redIndicatorMaterial.color = new Color(.25f,0f,0f);
        }

        private void ClearKeyPadScreen()
        {
            _currentLength = 0;
            _screenText = string.Empty;
        }

        private void ResetKeyPad()
        {
            FlashRedLight();
            PlayIncorrectSound();
            Invoke(nameof(ClearKeyPadScreen), 1f);
        }

        private void PlayIncorrectSound()
        {
            _keypadAudio.clip = codeWrongSound;
            _keypadAudio.PlayDelayed(.1f);
        }

        private void PlayCorrectSound()
        {
            _keypadAudio.clip = codeCorrectSound;
            _keypadAudio.PlayDelayed(.1f);
            if (dialogue != null)
            {
                dialogue.PlayDialogue(dialogue.dialogue4);
            }
        }

        public void DisableKeypad()
        {
            DisableButtons();
        }

        public void EnableKeypad()
        {
            EnableButtons();
        }

        public bool Solved()
        {
            return _solved;
        }
    }
}
