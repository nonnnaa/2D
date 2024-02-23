using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeAudio : MonoBehaviour
{
    AudioSource audio;
    void Start()
    {
        audio = GetComponent<AudioSource>();    
        audio.Play();
    }

}
