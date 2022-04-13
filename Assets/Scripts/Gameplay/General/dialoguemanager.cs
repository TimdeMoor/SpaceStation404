using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    AudioSource audiosource;
    [SerializeField] public AudioClip dialogue1and2;
    [SerializeField] public AudioClip dialogue3;
    [SerializeField] public AudioClip dialogue4;

    private void Start()
    {
        audiosource = GetComponent<AudioSource>();
        PlayDialogue(dialogue1and2);
    }

    public void PlayDialogue(AudioClip audioclip)
    {
        audiosource.clip = audioclip;
        audiosource.Play();
    }
}
