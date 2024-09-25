using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] AudioSource sceneryAudioSource;
    [SerializeField] AudioSource effectAudioSource;

    public void Listen(AudioClip clip)
    {
        Debug.Log($"Listen : {clip}");
        effectAudioSource.PlayOneShot(clip);
    }
}
