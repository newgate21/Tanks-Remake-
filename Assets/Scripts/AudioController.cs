using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    AudioSource[] Source;
    private void Awake()
    {
        Source = GetComponents<AudioSource>();
    }

    public void PlayClip(AudioClip _clip)
    {
        for (int i = 0; i < Source.Length; i++)
        {
            if (!Source[i].isPlaying)
            {
                Source[i].clip = _clip;
                Source[i].Play();
                break;
            }
        }
    }
}
