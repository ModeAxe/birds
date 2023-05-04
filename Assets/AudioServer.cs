using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioServer : MonoBehaviour
{
    public List<AudioClip> birdSounds = new List<AudioClip>();

    public List<AudioClip> indexedBirdSounds = new List<AudioClip>();

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public AudioClip GetBirdSound()
    {
        int audio_index = (int)Random.Range(0, birdSounds.Count);
        AudioClip sound = birdSounds[audio_index];
        return sound;
    }

    public AudioClip GetBirdSound(int index)
    {
        return GetBirdSound();
        AudioClip sound = indexedBirdSounds[index];
        return sound;
    }
}
