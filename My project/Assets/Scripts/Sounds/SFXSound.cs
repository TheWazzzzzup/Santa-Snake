using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXSound : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;

    [SerializeField] bool isLooping;

    public void PlaySound()
    {
        if (isLooping)
        {
            audioSource.loop = true;
        }

        audioSource.Play();
    }
}
