using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialougeHandler : MonoBehaviour
{
    public string[] DialogueArray;
    public AudioClip[] AudioClipArray;
    public AudioClip[] VFXSounds;
    public AudioSource dialogueSource;

    public bool clipIsPlaying;



    private void Update()
    {
        clipIsPlaying = dialogueSource.isPlaying;
    }

    public void playDialouge(int DialogueId)
    {
        //Incase we want text
    }
    public void playAudioClip(int clipId)
    {
        if (!clipIsPlaying)
        {

            dialogueSource.PlayOneShot(AudioClipArray[clipId]);

        }
    }
    public void playVFXSound(int clipId)
    {
           dialogueSource.PlayOneShot(VFXSounds[clipId]);
    }
}
