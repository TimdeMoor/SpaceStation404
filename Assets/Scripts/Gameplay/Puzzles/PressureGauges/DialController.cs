using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gameplay.General;
using TMPro;
using UnityEngine;

namespace Gameplay.Puzzles.PressureGauges
{
    public class DialController : MonoBehaviour
    {
        private List<Dial> _dials;
        private TextMeshPro _codeText;
        private string _currentCode;
        private AudioSource _audioSource;
        private StringBuilder _sb;
        private bool _active;
        void Start()
        {
            _sb = new StringBuilder();
            _codeText = GetComponentInChildren<TextMeshPro>();
            _dials = GetComponentsInChildren<Dial>().ToList();
            _audioSource = GetComponent<AudioSource>();
        }
    
        void Update()
        {
            if (!_active) return;
            
            _currentCode = GetCodeString();

            if (_codeText.text != _currentCode)
            {
                PlayClickSound();
            }

            _codeText.text = _currentCode;
        }

        private string GetCodeString()
        {
            _sb.Clear();

            foreach (Dial dial in _dials)
            {
                string stringFormat = "00";
                _sb.Append(dial.GetValue().ToString(stringFormat));
            }
            
            return _sb.ToString();
        }

        private void PlayClickSound()
        {
            _audioSource.Play();
        }

        public void Activate()
        {
            _active = true;
            
            foreach (var dial in GetComponentsInChildren<MouseDragRotate>())
            {
                dial.gameObject.GetComponent<Collider>().enabled = true;
            }
        }

        public void Deactivate()
        {
            _active = false;

            foreach (var dial in GetComponentsInChildren<MouseDragRotate>())
            {
                dial.gameObject.GetComponent<Collider>().enabled = false;
            }
        }
    }
}
