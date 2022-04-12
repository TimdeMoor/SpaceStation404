using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialoguemanager : MonoBehaviour
{
    AudioSource audiosource;
    [SerializeField] public AudioClip dialogue1_2;
    [SerializeField] public AudioClip dialogue3;
    [SerializeField] public AudioClip dialogue4;
    bool dialogue1_2played = false;
    bool dialogue3played = false;
    bool dialogue4played = false;

    private void Start()
    {
        audiosource = GetComponent<AudioSource>();
        PlayDialogue(dialogue1_2);
    }

    public void PlayDialogue(AudioClip audioclip)
    {
        audiosource.clip = audioclip;
        audiosource.Play();

    }


}
