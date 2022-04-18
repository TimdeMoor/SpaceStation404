using UnityEngine;

namespace Gameplay.General
{
    public class AudioManager : MonoBehaviour
    {
        private AudioSource _backGroundMusic;
        private AudioSource _dialogueManager;
        void Start()
        {
            _backGroundMusic = GetComponentInChildren<Dummy>().gameObject.GetComponent<AudioSource>();
            _dialogueManager = GetComponentInChildren<DialogueManager>().gameObject.GetComponent<AudioSource>();
        }

        void Update()
        {
            _backGroundMusic.volume = _dialogueManager.isPlaying ? .01f : .03f;
        }
    }
}
