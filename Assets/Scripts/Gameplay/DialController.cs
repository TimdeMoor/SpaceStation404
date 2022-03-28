using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMPro;
using UnityEngine;

namespace Gameplay
{
    public class DialController : MonoBehaviour
    {
        private List<Dial> _dials;
        private TextMeshPro _codeText;
        private string _currentCode;


        private StringBuilder _sb;
        void Start()
        {
            _sb = new StringBuilder();
            _codeText = GetComponentInChildren<TextMeshPro>();
            _dials = GetComponentsInChildren<Dial>().ToList();
        }
    
        void Update()
        {
            _currentCode = GetCodeString();
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
    }
}
