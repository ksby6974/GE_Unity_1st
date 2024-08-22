using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    [SerializeField] AudioSource effectAudioSource;

    public static SoundManager Instance
    {
        get { return instance; }
        set { instance = value; }
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Sound(AudioClip audioClip)
    {
        effectAudioSource.PlayOneShot(audioClip);
    }
}
