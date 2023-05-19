using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SFXSound : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;


    [SerializeField] bool isLooping;

    AudioMixer audioMixer;
    
    
    public void PlaySound()
    {
        if (isLooping)
        {
            audioSource.loop = true;
        }

        audioSource.Play();
    }
}
