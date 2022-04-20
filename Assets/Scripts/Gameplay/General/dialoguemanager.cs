using UnityEngine;

namespace Gameplay.General
{
    public class dialoguemanager : MonoBehaviour
    {
        AudioSource _audioSource;
        [SerializeField] public AudioClip dialogue1and2;
        [SerializeField] public AudioClip dialogue3;
        [SerializeField] public AudioClip dialogue4;
        [SerializeField] public AudioClip creditdialogue;

        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
            PlayDialogue(dialogue1and2);
        }

        public void PlayDialogue(AudioClip audioClip)
        {
            _audioSource.clip = audioClip;
            _audioSource.Play();
        }
    }
}