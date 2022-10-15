using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicPlayer : MonoBehaviour
{
    private void Awake()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        PlayMusic();       
    }

    private void PlayMusic()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }
}
